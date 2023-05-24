namespace AudioStreaming.Services.ArtistService
{
  public class ArtistService : IArtistService
  {
    private readonly DataContext _context;

    public ArtistService(DataContext context)
    {
      _context = context;
    }

    public async Task<List<Artist>> Add(Artist artist)
    {
      _context.Artists.Add(artist);
      await _context.SaveChangesAsync();
      return await _context.Artists.ToListAsync();
    }

    public async Task<List<Artist>?> Delete(int id)
    {
      var artist = await _context.Artists.FindAsync(id);
      if (artist is null)
        return null;

      _context.Artists.Remove(artist);
      await _context.SaveChangesAsync();

      return await _context.Artists.ToListAsync();
    }

    public async Task<List<Artist>> GetAll()
    {
      var artists = await _context.Artists.ToListAsync();
      return artists;
    }

    public async Task<Artist?> GetSingle(int id)
    {
      var artist = await _context.Artists.FindAsync(id);
      if (artist is null)
        return null;

      return artist;
    }

    public async Task<List<Artist>?> Update(int id, Artist request)
    {
      var artist = await _context.Artists.FindAsync(id);
      if (artist is null)
        return null;

      artist.Name = request.Name;
      artist.ImageUrl = request.ImageUrl;

      await _context.SaveChangesAsync();

      return await _context.Artists.ToListAsync();
    }
  }
}
