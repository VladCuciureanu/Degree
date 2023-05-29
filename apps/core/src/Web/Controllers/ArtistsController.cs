using AudioStreaming.Application.Common.Models;
using AudioStreaming.Application.Artists.Commands.CreateArtist;
using AudioStreaming.Application.Artists.Commands.DeleteArtist;
using AudioStreaming.Application.Artists.Commands.UpdateArtist;
using AudioStreaming.Application.Artists.Queries;
using AudioStreaming.Application.Artists.Queries.GetArtistsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AudioStreaming.Application.Artists.Queries.GetArtist;

namespace AudioStreaming.Web.Controllers;

[Route("api/artists")]
public class ArtistsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ArtistDto>>> GetArtistsWithPagination([FromQuery] GetArtistsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ArtistDto>> GetArtist(int id)
    {
        return await Mediator.Send(new GetArtistQuery(id));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateArtistCommand command)
    {
        return await Mediator.Send(command);
    }

    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateArtistCommand command)
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
        await Mediator.Send(new DeleteArtistCommand(id));

        return NoContent();
    }
}