using BlogApplicationAPI.Models;

namespace BlogApplicationAPI.ViewModel
{
    public class BlogEditViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string BlogPost { get; set; }

        public BlogEditViewModel(Blog blog)
        {
            Id = blog.Id.ToString();
            Title = blog.Title;
            Summary = blog.Summary;
            BlogPost = blog.BlogPost;
        }
    }
}
