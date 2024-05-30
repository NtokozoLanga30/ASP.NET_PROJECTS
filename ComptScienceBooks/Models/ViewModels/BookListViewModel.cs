using System.Reflection;

namespace ComptScienceBooks.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfoViewModel PagingInfo { get; set; }

    }
}
