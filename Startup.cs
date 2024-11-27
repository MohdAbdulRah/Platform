using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace BlogPlatform
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api";
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private static List<Post> posts = new List<Post>
        {
            new Post { Id = 1, Title = "First Post", Excerpt = "This is the first post." }
        };

        [HttpGet]
        public IActionResult GetPosts()
        {
            return Ok(posts);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            post.Id = posts.Count + 1;
            posts.Add(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = posts.Find(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
