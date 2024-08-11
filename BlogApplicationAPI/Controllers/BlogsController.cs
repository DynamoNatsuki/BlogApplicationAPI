using BlogApplicationAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet(Name = "GetBlogs")]
        public async Task<IEnumerable<BlogIndexViewModel>> Get()
        {
            var db = new Database();
            var blogs = await db.GetBlogs();

            var viewModel = new List<BlogIndexViewModel>();

            foreach (var blog in blogs)
            {
                viewModel.Add(new BlogIndexViewModel(blog));
            }

            return viewModel;
        }

        [HttpGet("{id}", Name = "GetBlogById")]
        public async Task<BlogDetailsViewModel> GetById(string id)
        {
            var db = new Database();
            var blog = await db.GetBlog(id);

            var viewModel = new BlogDetailsViewModel(blog); 

            return viewModel;
        }

        [HttpPost(Name = "PostBlog")]
        public async Task<IActionResult> Post(string title, string summary, string blogPost)
        {
            var db = new Database();
            await db.SaveBlog(title, summary, blogPost);

            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteBlog")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var db = new Database();
            await db.DeleteBlog(id);

            return Ok();
        }

        [HttpPut("{id}", Name = "PutBlog")]
        public async Task<IActionResult> PutBlog(string id, string title, string summary, string blogPost)
        {
            var db = new Database();
            await db.UpdateBlog(id, title, summary, blogPost);
            return Ok();
        }
    }
}
