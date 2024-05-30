using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ComptScienceBooks.Data
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private ICategoryRepository _category;
        private IBookRepository _book;
        private BookDbContext _bookDbContext;
        public RepositoryWrapper(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;   
        }

        public IBookRepository Book
        {
            get
            {
                if(_book==null)
                {
                    _book = new BookRepository(_bookDbContext);
                }
                return _book;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if(_category==null)
                {
                    _category = new CategoryRepository(_bookDbContext);
                }
                return _category;
            }
        }

        public void Save()
        {
            _bookDbContext.SaveChanges();
        }
    }
}
