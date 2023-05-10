namespace ShengFengDesign.Models.Album
{
    public class AlbumModel
    {
        public string ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
        public int Author_ID { get; set; }

        public string AuthorJobTitle { get; set; }
        public string AuthorDescription { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}
