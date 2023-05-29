using AudioStreaming.Application.Artists.Queries;
using AudioStreaming.Application.Common.Models;
using AudioStreaming.Application.Tracks.Commands.CreateTrack;
using AudioStreaming.Application.Tracks.Commands.DeleteTrack;
using AudioStreaming.Application.Tracks.Commands.UpdateTrack;
using AudioStreaming.Application.Tracks.Queries;
using AudioStreaming.Application.Tracks.Queries.GetTrack;
using AudioStreaming.Application.Tracks.Queries.GetTrackArtists;
using AudioStreaming.Application.Tracks.Queries.GetTracksWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Web.Controllers;

[Route("api/tracks")]
public class TracksController : ApiControllerBase
{
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
}
