using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Munchin.BookStore.Models;
using Munchin.BookStore.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munchin.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController( BookRepositry bookRepositry, LanguageRepository languageRepository )
        {
            _bookRepository = bookRepositry;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks( )
        {
            var data = await _bookRepository.GetAllBooks();

            return View( data );
        }

        public async Task<ViewResult> GetBook( int id )
        {
            var data = await _bookRepository.GetBookById( id );

            return View( data );
        }

        public List<BookModel> SearchBooks( string bookName, string authorName )
        {
            return _bookRepository.SearchBook( bookName, authorName );
        }

        public async Task<ViewResult> AddNewBook( bool isSuccess = false, int bookId = 0 )
        {
            var model = new BookModel();

            ViewBag.Language = new SelectList( await _languageRepository.GetLanguages(), "Id", "Name" );

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View( model );
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook( BookModel bookModel )
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook( bookModel );
                if(id > 0)
                {
                    return RedirectToAction( nameof( AddNewBook ), new { isSuccess = true, bookId = id } );
                }
            }

            ViewBag.Language = new SelectList( await _languageRepository.GetLanguages(), "Id", "Name" );

            return View();
        }
    }
}
