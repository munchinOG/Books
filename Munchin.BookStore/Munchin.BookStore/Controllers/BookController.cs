﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Munchin.BookStore.Models;
using Munchin.BookStore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Munchin.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public BookController( BookRepositry bookRepositry,
            LanguageRepository languageRepository,
            IWebHostEnvironment webHostEnviroment )
        {
            _bookRepository = bookRepositry;
            _languageRepository = languageRepository;
            _webHostEnviroment = webHostEnviroment;
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
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    bookModel.CoverImageUrl = await UploadImage( folder, bookModel.CoverPhoto );
                }

                if(bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();

                    foreach(var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage( folder, file )
                        };
                        bookModel.Gallery.Add( gallery );

                    }
                }

                int id = await _bookRepository.AddNewBook( bookModel );
                if(id > 0)
                {
                    return RedirectToAction( nameof( AddNewBook ), new { isSuccess = true, bookId = id } );
                }
            }

            ViewBag.Language = new SelectList( await _languageRepository.GetLanguages(), "Id", "Name" );

            return View();
        }

        private async Task<string> UploadImage( string folderPath, IFormFile file )
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine( _webHostEnviroment.WebRootPath, folderPath );

            await file.CopyToAsync( new FileStream( serverFolder, FileMode.Create ) );

            return "/" + folderPath;
        }
    }
}
