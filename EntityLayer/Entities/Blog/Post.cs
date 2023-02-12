using MessagePack;

namespace EntityLayer.Entities.Blog
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public List<Tag>? Tags { get; set; } = new List<Tag>();
        public List<Image>? Images { get; set; } = new List<Image>();
        public DateTime CreateDate { get; set; }
        public string? Thumbnail { get; set; }
        public string? MainTheme { get; set; }
        public int HasMainTheme { get; set; }
        public int Status { get; set; }

    }
}
