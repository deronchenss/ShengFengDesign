using ShengFengDesign.Models.Album;

namespace ShengFengDesign.Services.Interface
{
    public interface IAlbumService
    {
        Task<List<AlbumModel>> GetAlbumList(string culture = "");

        Task<AlbumModel> GetAlbum(string id, string culture = "");
    }
}
