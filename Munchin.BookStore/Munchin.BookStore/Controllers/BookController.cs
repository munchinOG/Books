using Microsoft.AspNetCore.Mvc;
using Munchin.BookStore.Models;
using Munchin.BookStore.Repository;
using System.Collections.Generic;

namespace Munchin.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepository = null;
        public BookController( BookRepositry bookRepositry )
        {
            _bookRepository = bookRepositry;
        }
        public ViewResult GetAllBooks( )
        {
            var data = _bookRepository.GetAllBooks();

            return View( data );
        }

        public ViewResult GetBook( int id )
        {
            var data = _bookRepository.GetBookById( id );

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
        public IActionResult AddNewBook( BookModel bookModel )
        {
            int id = _bookRepository.AddNewBook( bookModel );
            if(id > 0)
            {
                return RedirectToAction( nameof( AddNewBook ), new { isSuccess = true, bookId = id } );
            }
            return View();
        }
    }
}
