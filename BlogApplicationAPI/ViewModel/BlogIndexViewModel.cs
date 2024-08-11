using BlogApplicationAPI.Models;

namespace BlogApplicationAPI.ViewModel
{
    public class BlogIndexViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public BlogIndexViewModel(Blog blog)
        {
            Id = blog.Id.ToString();
            Title = blog.Title;
            Summary = blog.Summary;
        }
    }
}
