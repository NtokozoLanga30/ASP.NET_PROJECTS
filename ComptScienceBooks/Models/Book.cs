using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComptScienceBooks.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required (ErrorMessage = "Enter book name.")]
        [StringLength(30)]
        [DisplayName("Book Name")]
        public string BookName { get; set; }
        [Required (ErrorMessage = "Enter book author.")]
        [StringLength(30)]
        [DisplayName("Book Author")]        
        public string BookAuthor { get; set; }
        [Required]
        [DisplayName("Book Price")]
        public decimal BookPrice { get; set; }
        [Required (ErrorMessage = "Enter book description.")]
        [StringLength(1000)]
        [DisplayName("Book Description")]
        public string BookDescription { get; set; }
        [Required]
        public bool BookIsInStock { get; set; }
        [Required (ErrorMessage = "Enter book ISBN.")]
        [DisplayName("Book ISBN")]
        [StringLength(30)]
        public string BookISBN { get; set; }
        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        public string Slug =>
                BookName?.Replace(' ', '-').ToLower();
    }
}
