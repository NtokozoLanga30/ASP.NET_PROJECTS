namespace ComptScienceBooks.Data
{
    public interface IRepositoryWrapper
    {
        IBookRepository Book { get; }
        ICategoryRepository Category { get; }
        void Save();
       

    }
}
