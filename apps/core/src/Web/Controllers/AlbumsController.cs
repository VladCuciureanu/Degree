using AudioStreaming.Application.Common.Models;
using AudioStreaming.Application.Albums.Commands.CreateAlbum;
using AudioStreaming.Application.Albums.Commands.DeleteAlbum;
using AudioStreaming.Application.Albums.Commands.UpdateAlbum;
using AudioStreaming.Application.Albums.Queries;
using AudioStreaming.Application.Albums.Queries.GetAlbumsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AudioStreaming.Application.Albums.Queries.GetAlbum;
using AudioStreaming.Application.Tracks.Queries.GetAlbumTracks;
using AudioStreaming.Application.Tracks.Queries;

namespace AudioStreaming.Web.Controllers;

[Route("api/albums")]
public class AlbumsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<AlbumDto>>> GetAlbumsWithPagination([FromQuery] GetAlbumsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlbumDto>> GetAlbum(int id)
    {
        return await Mediator.Send(new GetAlbumQuery(id));
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> Create(CreateAlbumCommand command)
    {
        return await Mediator.Send(command);
    }

    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateAlbumCommand command)
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
        await Mediator.Send(new DeleteAlbumCommand(id));

        return NoContent();
    }

    [HttpGet("{id}/tracks")]
    public async Task<ActionResult<List<TrackDto>>> GetAlbumTracks(int id)
    {
        return await Mediator.Send(new GetAlbumTracksQuery(id));
    }
}