using Microsoft.AspNetCore.Mvc;
using AudioStreaming.Services.TrackService;

namespace AudioStreaming.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TrackController : ControllerBase
  {
    private readonly ITrackService _trackService;

    public TrackController(ITrackService trackService)
    {
      _trackService = trackService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Track>>> GetAll()
    {
      return await _trackService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Track>> GetSingle(int id)
    {
      var result = await _trackService.GetSingle(id);
      if (result is null)
        return NotFound();

      return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Track>>> Add(Track track)
    {
      var result = await _trackService.Add(track);
      return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Track>>> Update(int id, Track request)
    {
      var result = await _trackService.Update(id, request);
      if (result is null)
        return NotFound();

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Track>>> Delete(int id)
    {
      var result = await _trackService.Delete(id);
      if (result is null)
        return NotFound();

      return Ok(result);
    }
  }
}
