using ShengFengDesign.Models;
using ShengFengDesign.Models.Album;

namespace ShengFengDesign.Repository.Interface
{
    public interface IRepository
    {
        Task<bool> SaveContactUs(ContactUs contactus);
        Task<List<AlbumModel>> GetAlbumList(string culture);
        Task<AlbumModel> GetAlbum(string id, string culture = "");
    }
}
