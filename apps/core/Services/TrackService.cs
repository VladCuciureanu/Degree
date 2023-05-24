namespace AudioStreaming.Services.TrackService
{
  public class TrackService : ITrackService
  {
    private readonly DataContext _context;

    public TrackService(DataContext context)
    {
      _context = context;
    }

    public async Task<List<Track>> Add(Track track)
    {
      _context.Tracks.Add(track);
      await _context.SaveChangesAsync();
      return await _context.Tracks.ToListAsync();
    }

    public async Task<List<Track>?> Delete(int id)
    {
      var track = await _context.Tracks.FindAsync(id);
      if (track is null)
        return null;

      _context.Tracks.Remove(track);
      await _context.SaveChangesAsync();

      return await _context.Tracks.ToListAsync();
    }

    public async Task<List<Track>> GetAll()
    {
      var tracks = await _context.Tracks.ToListAsync();
      return tracks;
    }

    public async Task<Track?> GetSingle(int id)
    {
      var track = await _context.Tracks.FindAsync(id);
      if (track is null)
        return null;

      return track;
    }

    public async Task<List<Track>?> Update(int id, Track request)
    {
      var track = await _context.Tracks.FindAsync(id);
      if (track is null)
        return null;

      track.Name = request.Name;

      await _context.SaveChangesAsync();

      return await _context.Tracks.ToListAsync();
    }
  }
}
