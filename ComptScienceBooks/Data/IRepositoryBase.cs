namespace ComptScienceBooks.Data
{
    public interface IRepositoryBase<T>
    {
        T GetById(int id);
        IEnumerable<T> FindAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
