using AudioStreaming.Application.Common.Models;
using AudioStreaming.Application.Albums.Commands.CreateAlbum;
using AudioStreaming.Application.Albums.Commands.DeleteAlbum;
using AudioStreaming.Application.Albums.Commands.UpdateAlbum;
using AudioStreaming.Application.Albums.Queries.GetAlbumsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AudioStreaming.Web.Controllers;

[Authorize]
public class AlbumsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<AlbumDto>>> GetAlbumsWithPagination([FromQuery] GetAlbumsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateAlbumCommand command)
    {
        return await Mediator.Send(command);
    }

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

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteAlbumCommand(id));

        return NoContent();
    }
}
