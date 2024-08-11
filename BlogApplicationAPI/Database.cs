using BlogApplicationAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BlogApplicationAPI
{
    public class Database
    {
        private IMongoDatabase GetDB()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BlogsDB");
            return db;
        }

        public async Task<List<Blog>> GetBlogs()
        {
            var blogs = await GetDB().GetCollection<Blog>("Blogs")
                .Find(b => true)
                .ToListAsync();

            return blogs;
        }

        public async Task<Blog> GetBlog(string id)
        {
            ObjectId _id = new ObjectId(id);

            var recipe = await GetDB().GetCollection<Blog>("Blogs")
                .Find(b => b.Id == _id)
                .SingleOrDefaultAsync();

            return recipe;
        }

        public async Task SaveBlog(string title, string summary, string blogPost)
        {
            var blog = new Blog
            {
                Title = title,
                Summary = summary,
                BlogPost = blogPost
            };

            await GetDB().GetCollection<Blog>("Blogs")
                .InsertOneAsync(blog);
        }

        public async Task DeleteBlog(string id)
        {
            ObjectId _id = new ObjectId(id);

            await GetDB().GetCollection<Blog>("Blogs")
                .DeleteOneAsync(b => b.Id==_id);
        }

        public async Task UpdateBlog(string id, string title, string summary, string blogPost)
        {
            ObjectId _id = new ObjectId(id);

            var update = Builders<Blog>.Update
                .Set(b => b.Title, title)
                .Set(b => b.Summary, summary)
                .Set(b => b.BlogPost, blogPost);

            await GetDB().GetCollection<Blog>("Blogs")
                .UpdateOneAsync(b => b.Id ==_id, update);
        }
    }
}
