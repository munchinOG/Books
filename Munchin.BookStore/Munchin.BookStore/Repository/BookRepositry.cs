using Microsoft.EntityFrameworkCore;
using Munchin.BookStore.Data;
using Munchin.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munchin.BookStore.Repository
{
    public class BookRepositry
    {
        private readonly BookStoreContext _context = null;

        public BookRepositry( BookStoreContext context )
        {
            _context = context;
        }
        public async Task<int> AddNewBook( BookModel model )
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreateOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPage = model.TotalPage.HasValue ? model.TotalPage.Value : 0,
                UpdateOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync( newBook );
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks( )
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach(var book in allbooks)
                {
                    books.Add( new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPage = book.TotalPage
                    } );
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById( int id )
        {
            var book = await _context.Books.FindAsync( id );
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPage = book.TotalPage
                };

                return bookDetails;
            }

            return null;

        }

        public List<BookModel> SearchBook( string title, string authorName )
        {
            return DataSource().Where( x => x.Title.Contains( title ) || x.Author.Contains( authorName ) ).ToList();
        }

        private List<BookModel> DataSource( )
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title = "MVC", Author = "Munchin", Description = "This is the description for MVC book", Category = "Programming", Language = "English", TotalPage = 134},
                new BookModel(){Id = 2, Title = "Dot Net Core", Author = "Munchin", Description = "This is the description for DOT NET CORE book", Category = "Framework", Language = "Pigin", TotalPage = 150},
                new BookModel(){Id = 3, Title = "React", Author = "Kate", Description = "This is the description for REACT book", Category = "Developer", Language = "Hindi", TotalPage = 200},
                new BookModel(){Id = 4, Title = "Java", Author = "Utibe", Description = "This is the description for JAVA book", Category = "Concept", Language = "English", TotalPage = 321},
                new BookModel(){Id = 5, Title = "Php", Author = "Mike", Description = "This is the description for PHP book", Category = "Programming", Language = "English", TotalPage = 120},
                new BookModel(){Id = 6, Title = "Azure Dev", Author = "Tolu", Description = "This is the description for Azure Dev book", Category = "DevOps", Language = "Chinese", TotalPage = 259},
            };
        }
    }
}
