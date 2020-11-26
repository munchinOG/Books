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
                LanguageId = model.LanguageId,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
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
                        LanguageId = book.LanguageId,
                        Language = book.Language.Name,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    } );
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById( int id )
        {
            return await _context.Books.Where( x => x.Id == id )
                .Select( book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                } ).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook( string title, string authorName )
        {
            return null;
        }
    }
}
