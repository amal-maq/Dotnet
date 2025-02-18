using Microsoft.EntityFrameworkCore;
using BlogPlatform.Data;
using BlogPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPlatform.Services
{
    public class BlogService : IBlogService
    {
        private readonly BlogDbContext _context;

        public BlogService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog> UpdateBlogAsync(int id, Blog blog)
        {
            var existingBlog = await _context.Blogs.FindAsync(id);
            if (existingBlog != null)
            {
                existingBlog.Title = blog.Title;
                existingBlog.Author = blog.Author;
                existingBlog.Content = blog.Content;
                existingBlog.PublishDate = blog.PublishDate;
                existingBlog.Category = blog.Category;
                await _context.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
