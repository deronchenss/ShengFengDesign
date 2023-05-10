using ShengFengDesign.Models;
using ShengFengDesign.Models.Album;
using ShengFengDesign.Repository.Interface;
using ShengFengDesign.Services.Interface;
using System.Text.RegularExpressions;

namespace ShengFengDesign.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository _Repository;

        public AlbumService(IRepository blogRepository)
        {
            _Repository = blogRepository;
        }

        public Task<AlbumModel> GetAlbum(string id, string culture = "")
        {
            return _Repository.GetAlbum(id, culture);
        }

        public Task<List<AlbumModel>> GetAlbumList(string culture = "")
        {
            return _Repository.GetAlbumList(culture);
        }
    }
}
