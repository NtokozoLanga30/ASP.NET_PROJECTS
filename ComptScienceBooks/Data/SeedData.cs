using ComptScienceBooks.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;

namespace ComptScienceBooks.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BookDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                new Category { CategoryName = "Network Security" }, //Category 1
                new Category { CategoryName = "Software Engineering" }, //Category 2
                new Category { CategoryName = "Programming" }, //Category 3
                new Category { CategoryName = "Human Computer Interaction"},//Category 4
                new Category { CategoryName = "Machine Learning"}); //Category 5
            }
            context.SaveChanges();
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                new Book
                {
                    BookName = "Security Essentials",
                    BookAuthor = "Ben Dean",
                    BookPrice = 786.90M,
                    BookDescription = "Defend networks against cyber threats; Discover best practices for penetration testing.",
                    BookIsInStock = true,
                    BookISBN = "45-63-65-41",
                    CategoryId = 1
                },
                new Book
                {
                    BookName = "Refactoring for Novices",
                    BookAuthor = "Ben Jean",
                    BookPrice = 286.90M,
                    BookDescription = "As any working programmer knows, writing your code is one thing, but refactoring is another skill altogether. ",
                    BookIsInStock = true,
                    BookISBN = "45-00-65-00",
                    CategoryId = 3
                },

                new Book
                {
                    BookName = "Designing the UI",
                    BookAuthor = "Allian Yeall",
                    BookPrice = 776.90M,
                    BookDescription = "Provides Strategies for Effective Human-Computer Interaction.",
                    BookIsInStock = true,
                    BookISBN = "11-63-65-22",
                    CategoryId = 4,
                },

                new Book
                {
                    BookName = "Machines for Begginers",
                    BookAuthor = "Oliver Theobald",
                    BookPrice = 386.90M,
                    BookDescription = "The book provides a high-level introduction to machine learning and it is Best for absolute beginners.",
                    BookIsInStock = true,
                    BookISBN = "10-63-65-01",
                    CategoryId = 5
                },

                new Book
                {
                    BookName = "Contextual Design",
                    BookAuthor = "Danger Primary",
                    BookPrice = 686.90M,
                    BookDescription = "Design for Life, Second Edition, describes the core techniques needed to deliberately produce a compelling user experience. ",
                    BookIsInStock = true,
                    BookISBN = "45-63-65-41",
                    CategoryId = 4,
                },

                new Book
                {
                    BookName = "Introduction to Algorithms",
                    BookAuthor = "John Stuawards",
                    BookPrice = 396.90M,
                    BookDescription = "Assist with extensive coverage of algorithms coupled with clear descriptions and pseudo-code. ",
                    BookIsInStock = true,
                    BookISBN = "34-01-90-41",
                    CategoryId = 3,
                },

                new Book
                {
                    BookName = "Mythical Man-Month",
                    BookAuthor = "Colen Radebe",
                    BookPrice = 806.90M,
                    BookDescription = "This fundamental software engineering book by Fredrick P. Brooks is the extended version of his best book about software engineers.",
                    BookIsInStock = true,
                    BookISBN = "00-63-02-03",
                    CategoryId = 2
                },

                new Book
                {
                    BookName = "Pragmatic Programmer",
                    BookAuthor = "Van Elk Dean",
                    BookPrice = 786.90M,
                    BookDescription = "This book entails a lot of knowledge about the core processes of software development and its aspects, such as personal.",
                    BookIsInStock = true,
                    BookISBN = "99-63-99-41",
                    CategoryId = 2
                },
                new Book
                {
                    BookName = "Hands on Machine Learning",
                    BookAuthor = "Daniel Modise",
                    BookPrice = 365.90M,
                    BookDescription = "Hands-On Machine Learning with Scikit-Learn, Keras, and TensorFlow 3e for beginners.",
                    BookIsInStock = false,
                    BookISBN = "10-63-00-01",
                    CategoryId = 5
                },
                new Book
                {
                    BookName = "Applied Security Monitoring",
                    BookAuthor = "Teko Modise",
                    BookPrice = 469.90M,
                    BookDescription = "It is an essential guide to becoming an NSM analyst from the ground up.",
                    BookIsInStock = true,
                    BookISBN = "00-11-00-22",
                    CategoryId = 1
                },
                new Book
                {
                    BookName = "Head First Java",
                    BookAuthor = "Peter Gabriel",
                    BookPrice = 365.90M,
                    BookDescription = "Head First Java book is perfect for java programmers who are new to coding.",
                    BookIsInStock = false,
                    BookISBN = "11-11-00-22",
                    CategoryId = 3
                },
                new Book
                {
                    BookName = "Experimental HCI",
                    BookAuthor = "Hellen Marry",
                    BookPrice = 369.90M,
                    BookDescription = "Head First Java book is perfect for java programmers who are new to coding.",
                    BookIsInStock = false,
                    BookISBN = "99-77-44-22",
                    CategoryId =  4
                });
            }
            context.SaveChanges();
        }
    }
}
