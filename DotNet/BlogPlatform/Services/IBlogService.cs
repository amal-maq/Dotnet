using BlogPlatform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPlatform.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> UpdateBlogAsync(int id, Blog blog);
        Task<bool> DeleteBlogAsync(int id);
    }
}
