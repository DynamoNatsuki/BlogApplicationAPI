using BlogApplicationAPI.Models;

namespace BlogApplicationAPI.ViewModel
{
    public class BlogDetailsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BlogPost { get; set; }

        public BlogDetailsViewModel(Blog blog)
        {
            Id = blog.Id.ToString();
            Title = blog.Title;
            BlogPost = blog.BlogPost;
        }
    }
}
