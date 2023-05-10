using ShengFengDesign.Services.Interface;
using ShengFengDesign.ViewModels.Home;
using ShengFengDesign.ViewModels.Album;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ShengFengDesign.Controllers
{
    [Route("{culture?}/album")]
    public class AlbumController : BaseController
    {
        private readonly IAlbumService _AlbumService;

        public AlbumController(IAlbumService AlbumService)
        {
            _AlbumService = AlbumService;
        }

        [Route("{id?}")]
        public async Task<IActionResult> Index(string culture, string id)
        {
            if (string.IsNullOrEmpty(id))
            { 
                var list = await _AlbumService.GetAlbumList(culture);
                var viewModel = new AlbumViewModel
                {
                    AlbumList = list.Select(
                        x => new AlbumItemViewModel
                        {
                            ID = x.ID,
                            Title = x.Title,
                            Content = x.Content.Length > 70 ? Markdown.ToHtml(x.Content[..70]) + "..." : Markdown.ToHtml(x.Content)
                        }).ToList()
                };

                return View(viewModel);
            }
            else
            {
                var list = await _AlbumService.GetAlbumList(culture);
                var data = await _AlbumService.GetAlbum(id, culture);
                var viewModel = new AlbumItemViewModel
                {
                    ID = data.ID,
                    Title = data.Title,
                    Content = Markdown.ToHtml(data.Content),
                    Author = data.Author,
                    AuthorJobTitle=data.AuthorJobTitle,
                    AuthorDescription = data.AuthorDescription,
                    ModifyTimeText = $"{data.ModifyTime.ToString("dd MMM, yyyy", CultureInfo.InvariantCulture)}",
                    AlbumList = list.Where(x => x.ID != data.ID).Select(
                        x => new AlbumItemViewModel
                        {
                            ID = x.ID,
                            Title = x.Title,
                            Content = Markdown.ToHtml(x.Content),
                            AuthorJobTitle = x.AuthorJobTitle,
                            AuthorDescription = x.AuthorDescription, 
                        }).ToList()
                };

                return View("Article", viewModel);
            }
        }

        public static string Parse(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();
            return Markdown.ToHtml(markdown, pipeline);
        }
    }
}
