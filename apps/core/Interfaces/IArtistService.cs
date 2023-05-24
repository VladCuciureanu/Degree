namespace AudioStreaming.Services.ArtistService
{
  public interface IArtistService
  {
    Task<List<Artist>> GetAll();
    Task<Artist?> GetSingle(int id);
    Task<List<Artist>> Add(Artist hero);
    Task<List<Artist>?> Update(int id, Artist request);
    Task<List<Artist>?> Delete(int id);
  }
}
