using Microsoft.AspNetCore.Mvc;
using Munchin.BookStore.Models;
using Munchin.BookStore.Repository;
using System.Collections.Generic;

namespace Munchin.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepository = null;
        public BookController( )
        {
            _bookRepository = new BookRepositry();
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

        public ViewResult AddNewBook( )
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddNewBook( BookModel bookModel )
        {
            return View();
        }
    }
}
