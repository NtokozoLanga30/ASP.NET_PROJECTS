using ComptScienceBooks.Data.Data_Access;
using ComptScienceBooks.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace ComptScienceBooks.Data
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
       
        public BookRepository(BookDbContext bookDbContext):base(bookDbContext)
        {
        }
        public IEnumerable<Book> GetBookWithCategoryDetailsOptions(QueryOptions<Book> options)
        {
            IQueryable<Book> query = _bookDbContext.Books
                .Include(c => c.Categories);

            if (options.HasWhere)
                query = query.Where(options.Where);

            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                    query = query.OrderBy(options.OrderBy);
                else
                    query = query.OrderByDescending(options.OrderBy);
            }
            if (options.HasPaging)
            {
                query = query.Skip((options.PageNumber - 1) * options.PageSize)
                             .Take(options.PageSize);
            }

            return query.ToList();

        }
    }
}
