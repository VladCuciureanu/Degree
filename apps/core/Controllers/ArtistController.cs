using Microsoft.AspNetCore.Mvc;
using AudioStreaming.Services.ArtistService;

namespace AudioStreaming.Controllers
{
  [Route("api/artists")]
  [ApiController]
  public class ArtistController : ControllerBase
  {
    private readonly IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
      _artistService = artistService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Artist>>> GetAll()
    {
      return await _artistService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Artist>> GetSingle(int id)
    {
      var result = await _artistService.GetSingle(id);
      if (result is null)
        return NotFound();

      return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Artist>>> Add(Artist artist)
    {
      var result = await _artistService.Add(artist);
      return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Artist>>> Update(int id, Artist request)
    {
      var result = await _artistService.Update(id, request);
      if (result is null)
        return NotFound();

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Artist>>> Delete(int id)
    {
      var result = await _artistService.Delete(id);
      if (result is null)
        return NotFound();

      return Ok(result);
    }
  }
}
