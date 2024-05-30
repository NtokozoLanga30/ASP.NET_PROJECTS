using ComptScienceBooks.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ComptScienceBooks.Data
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(BookDbContext bookDbContext): base(bookDbContext)
        {
            
        }
    }
}
