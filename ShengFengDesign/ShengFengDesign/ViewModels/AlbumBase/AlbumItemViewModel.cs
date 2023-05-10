namespace ShengFengDesign.ViewModels.Album
{
    public class AlbumItemViewModel
    {
        public string ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string AuthorJobTitle { get; set; }
        public string AuthorDescription { get; set; }
        public string ModifyTimeText { get; set; }

        public List<AlbumItemViewModel> AlbumList { get; set; }
    }
}
