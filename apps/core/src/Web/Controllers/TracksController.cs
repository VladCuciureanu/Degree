using AudioStreaming.Application.Common.Models;
using AudioStreaming.Application.Tracks.Commands.CreateTrack;
using AudioStreaming.Application.Tracks.Commands.DeleteTrack;
using AudioStreaming.Application.Tracks.Commands.UpdateTrack;
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
}
