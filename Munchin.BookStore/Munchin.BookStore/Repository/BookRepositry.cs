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
                UpdateOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl
            };

            newBook.bookGallery = new List<BookGallery>();

            foreach(var file in model.Gallery)
            {
                newBook.bookGallery.Add( new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                } );

            }

            await _context.Books.AddAsync( newBook );
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks( )
        {
            return await _context.Books
                .Select( book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                } ).ToListAsync();
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
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select( g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    } ).ToList()
                } ).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook( string title, string authorName )
        {
            return null;
        }
    }
}
