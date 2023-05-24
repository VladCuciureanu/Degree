namespace AudioStreaming.Services.AlbumService
{
  public class AlbumService : IAlbumService
  {
    private readonly DataContext _context;

    public AlbumService(DataContext context)
    {
      _context = context;
    }

    public async Task<List<Album>> Add(Album album)
    {
      _context.Albums.Add(album);
      await _context.SaveChangesAsync();
      return await _context.Albums.ToListAsync();
    }

    public async Task<List<Album>?> Delete(int id)
    {
      var album = await _context.Albums.FindAsync(id);
      if (album is null)
        return null;

      _context.Albums.Remove(album);
      await _context.SaveChangesAsync();

      return await _context.Albums.ToListAsync();
    }

    public async Task<List<Album>> GetAll()
    {
      var albums = await _context.Albums.ToListAsync();
      return albums;
    }

    public async Task<Album?> GetSingle(int id)
    {
      var album = await _context.Albums.FindAsync(id);
      if (album is null)
        return null;

      return album;
    }

    public async Task<List<Album>?> Update(int id, Album request)
    {
      var album = await _context.Albums.FindAsync(id);
      if (album is null)
        return null;

      album.Name = request.Name;
      album.ImageUrl = request.ImageUrl;

      await _context.SaveChangesAsync();

      return await _context.Albums.ToListAsync();
    }
  }
}
