using Microsoft.AspNetCore.Mvc;
using Munchin.BookStore.Models;
using Munchin.BookStore.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munchin.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepository = null;
        public BookController( BookRepositry bookRepositry )
        {
            _bookRepository = bookRepositry;
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

        public ViewResult AddNewBook( bool isSuccess = false, int bookId = 0 )
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
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
                //ViewBag.IsSuccess = false;
                //ViewBag.BookId = 0;
            }

            return View();
        }
    }
}
