namespace AudioStreaming.Services.TrackService
{
  public interface ITrackService
  {
    Task<List<Track>> GetAll();
    Task<Track?> GetSingle(int id);
    Task<List<Track>> Add(Track hero);
    Task<List<Track>?> Update(int id, Track request);
    Task<List<Track>?> Delete(int id);
  }
}
