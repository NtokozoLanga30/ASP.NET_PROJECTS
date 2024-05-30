using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComptScienceBooks.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Book> Book { get; set; }
    }
}
