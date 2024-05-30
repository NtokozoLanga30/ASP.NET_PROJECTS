using ComptScienceBooks.Data;
using ComptScienceBooks.Data.Data_Access;
using ComptScienceBooks.Models;
using ComptScienceBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace ComptScienceBooks.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
      
        public BookController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }  
        private int iPageSize = 4;
        public IActionResult List(string sortBy = "BookName", int bookPage =1)
        {
            IEnumerable<Book> books;
            Expression<Func<Book, Object>> orderBy;
            string orderByDirection;
            int iTotalBooks;


            ViewData["NameSortParam"] = sortBy == "BookName" ? "BookName_desc" : "BookName";
            ViewData["PriceSortParam"] = sortBy == "BookPrice" ? "BookPrice_desc" : "BookPrice";

            if (sortBy.EndsWith("_desc"))
            {
                sortBy = sortBy.Substring(0, sortBy.Length - 5);
                orderByDirection = "desc";
            }
            else
            {
                orderByDirection = "asc";
            }

            orderBy = p => EF.Property<object>(p, sortBy);
            iTotalBooks = _repositoryWrapper.Book.FindAll().Count();
            books = _repositoryWrapper.Book.GetBookWithCategoryDetailsOptions(new QueryOptions<Book>
            {
                OrderBy = orderBy,
                OrderByDirection = orderByDirection,
                 PageNumber = bookPage,
                PageSize = iPageSize

            });
            var model = new BookListViewModel
            {
                Books = books,
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = bookPage,
                    ItemsPerPage = iPageSize,
                    TotalItems = iTotalBooks
                }
            };

            return View(model);

        }

        public IActionResult Details(int id)
        {
            var Books = _repositoryWrapper.Book.GetById(id);
            return View(Books);
        }
        public IActionResult Add()
        {
            PopulateCategoryDLL();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Book.Add(book);
                _repositoryWrapper.Save();
                TempData["Message"] = $"{book.BookName} has been added";
                return RedirectToAction("List");
            }
            else
            {
                PopulateCategoryDLL();
                return View(book);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _repositoryWrapper.Book.GetById(id);
            PopulateCategoryDLL(book.CategoryId);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repositoryWrapper.Book.Update(book);
                    _repositoryWrapper.Save();
                    TempData["Message"] = $"{book.BookName} has been updated";
                    return RedirectToAction("List");
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            PopulateCategoryDLL(book.CategoryId);
            return View(book);
        }
        public IActionResult Delete(int id)
        {
            return View(_repositoryWrapper.Book.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            if (book != null)
            {
                try
                {
                    _repositoryWrapper.Book.Delete(book);
                    _repositoryWrapper.Save();
                    TempData["Message"] = $"The book has been deleted";
                    return RedirectToAction("List");
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to delete device. " +
                     "Try again, and if the problem persists, " +
                     "see your system administrator.");
                }
            }   
            return View(book);
        }
        private void PopulateCategoryDLL(object selectedCategory = null)
        {
            ViewBag.Categories = new SelectList(_repositoryWrapper.Category.FindAll()
                .OrderBy(g => g.CategoryName),
                "CategoryId", "CategoryName", selectedCategory);
        }
    }
}
