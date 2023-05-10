using ShengFengDesign.Middlewares;
using ShengFengDesign.Services.Interface;
using ShengFengDesign.ViewModels.Home;
using ShengFengDesign.ViewModels.Album;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ShengFengDesign.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAlbumService _AlbumService;

        public HomeController(IAlbumService AlbumService)
        {
            _AlbumService = AlbumService;
        }
        public async Task<IActionResult> Index(string culture)
        {
            var list = await _AlbumService.GetAlbumList(culture);
            var viewModel = new HomeViewModel
            {
                AlbumList = list.Select(
                    x => new AlbumItemViewModel
                    {
                        ID = x.ID,
                        Title = x.Title,
                        Content = x.Content.Length > 150 ? Markdown.ToHtml(x.Content[..150]) + "..." : Markdown.ToHtml(x.Content)
                    }).ToList()
            };

            viewModel.AlbumList = viewModel.AlbumList.Count > 3 ?
                viewModel.AlbumList.Take(3).ToList() : viewModel.AlbumList;

            return View(viewModel);
        }
    }
}
