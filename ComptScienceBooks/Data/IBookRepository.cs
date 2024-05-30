using ComptScienceBooks.Data.Data_Access;
using ComptScienceBooks.Models;
using System.Reflection;

namespace ComptScienceBooks.Data
{
    public interface IBookRepository: IRepositoryBase<Book>
    {
        IEnumerable<Book> GetBookWithCategoryDetailsOptions(QueryOptions<Book> options);

    }
}
