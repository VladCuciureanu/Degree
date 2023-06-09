using AudioStreaming.Application.Artists.Queries;
using AudioStreaming.Application.Common.Models;
using AudioStreaming.Application.Tracks.Commands.AddTrackArtist;
using AudioStreaming.Application.Tracks.Commands.CreateTrack;
using AudioStreaming.Application.Tracks.Commands.DeleteTrack;
using AudioStreaming.Application.Tracks.Commands.RemoveTrackArtist;
using AudioStreaming.Application.Tracks.Commands.UpdateTrack;
using AudioStreaming.Application.Tracks.Commands.UploadTrack;
using AudioStreaming.Application.Tracks.Queries;
using AudioStreaming.Application.Tracks.Queries.GetTrack;
using AudioStreaming.Application.Tracks.Queries.GetTrackArtists;
using AudioStreaming.Application.Tracks.Queries.GetTrackFile;
using AudioStreaming.Application.Tracks.Queries.GetTracksWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Web.Controllers;

[Route("api/tracks")]
public class TracksController : ApiControllerBase
{
    private readonly IHostEnvironment _environment;

    public TracksController(IHostEnvironment environment)
    {
        this._environment = environment;
    }
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TrackDto>>> GetTracksWithPagination([FromQuery] GetTracksWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrackDto>> GetTrack(int id)
    {
        return await Mediator.Send(new GetTrackQuery(id));
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> Create(CreateTrackCommand command)
    {
        return await Mediator.Send(command);
    }

    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateTrackCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTrackCommand(id));

        return NoContent();
    }

    [HttpGet("{id}/artists")]
    public async Task<ActionResult<List<ArtistDto>>> GetTrackArtists(int id)
    {
        return await Mediator.Send(new GetTrackArtistsQuery(id));
    }

    [Authorize]
    [HttpPost("{id}/artists")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ArtistDto>>> AddTrackArtist(int id, [FromQuery] AddTrackArtistCommand command)
    {
        if (id != command.TrackId)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}/artists")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ArtistDto>>> RemoveTrackArtist(int id, [FromQuery] RemoveTrackArtistCommand command)
    {
        if (id != command.TrackId)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpGet("{id}/content")]
    public async Task<IActionResult> GetFile(int id)
    {
        var fileUrl = await Mediator.Send(new GetTrackFileQuery(id));

        if (fileUrl == null)
        {
            return NoContent();
        }

        Stream payload = _environment.ContentRootFileProvider.GetFileInfo(fileUrl).CreateReadStream();

        return File(payload, "audio/mpeg", enableRangeProcessing: true);
    }

    [Authorize]
    [HttpPut("{id}/content")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UploadFile(int id, IFormFile file)
    {
        byte[] payload = await file.OpenReadStream().ToArrayAsync();

        String basePath = _environment.ContentRootPath;

        await Mediator.Send(new UploadTrackCommand(id, payload, basePath));

        return NoContent();
    }
}

public static class StreamExtensions
{
    public static async Task<byte[]> ToArrayAsync(this Stream stream)
    {
        var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}