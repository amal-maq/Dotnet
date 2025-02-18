using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Models;
using BlogPlatform.Services;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/blogs
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _blogService.GetAllBlogsAsync();
            return Ok(blogs);
        }

        // GET: api/blogs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        // POST: api/blogs
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] Blog blog)
        {
            if (blog == null || string.IsNullOrEmpty(blog.Title) || string.IsNullOrEmpty(blog.Author) || string.IsNullOrEmpty(blog.Content))
            {
                return BadRequest("Title, Author, and Content are required.");
            }

            var createdBlog = await _blogService.CreateBlogAsync(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = createdBlog.Id }, createdBlog);
        }

        // PUT: api/blogs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, [FromBody] Blog blog)
        {
            if (blog == null || string.IsNullOrEmpty(blog.Title) || string.IsNullOrEmpty(blog.Author) || string.IsNullOrEmpty(blog.Content))
            {
                return BadRequest("Title, Author, and Content are required.");
            }

            var updatedBlog = await _blogService.UpdateBlogAsync(id, blog);
            if (updatedBlog == null)
            {
                return NotFound();
            }

            return Ok(updatedBlog);
        }

        // DELETE: api/blogs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var success = await _blogService.DeleteBlogAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
