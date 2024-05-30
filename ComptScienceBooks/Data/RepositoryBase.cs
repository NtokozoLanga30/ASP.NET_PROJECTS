namespace ComptScienceBooks.Data
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected BookDbContext _bookDbContext;
        public RepositoryBase(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public void Add(T entity)
        {
            _bookDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _bookDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return _bookDbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _bookDbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _bookDbContext.Set<T>().Update(entity);
        }

    }
}
