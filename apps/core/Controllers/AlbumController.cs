using Microsoft.AspNetCore.Mvc;
using AudioStreaming.Services.AlbumService;
using Microsoft.AspNetCore.Authorization;

namespace AudioStreaming.Controllers
{
  [Route("api/albums")]
  [ApiController]
  public class AlbumController : ControllerBase
  {
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
      _albumService = albumService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Album>>> GetAll()
    {
      return await _albumService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Album>> GetSingle(int id)
    {
      var result = await _albumService.GetSingle(id);
      if (result is null)
        return NotFound();

      return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<List<Album>>> Add(Album album)
    {
      var result = await _albumService.Add(album);
      return Ok(result);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Album>>> Update(int id, Album request)
    {
      var result = await _albumService.Update(id, request);
      if (result is null)
        return NotFound();

      return Ok(result);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Album>>> Delete(int id)
    {
      var result = await _albumService.Delete(id);
      if (result is null)
        return NotFound();

      return Ok(result);
    }
  }
}
