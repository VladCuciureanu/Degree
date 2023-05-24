namespace AudioStreaming.Services.AlbumService
{
  public interface IAlbumService
  {
    Task<List<Album>> GetAll();
    Task<Album?> GetSingle(int id);
    Task<List<Album>> Add(Album hero);
    Task<List<Album>?> Update(int id, Album request);
    Task<List<Album>?> Delete(int id);
  }
}
