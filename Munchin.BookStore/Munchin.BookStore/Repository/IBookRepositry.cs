using Munchin.BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munchin.BookStore.Repository
{
    public interface IBookRepositry
    {
        Task<int> AddNewBook( BookModel model );
        Task<List<BookModel>> GetAllBooks( );
        Task<BookModel> GetBookById( int id );
        Task<List<BookModel>> GetTopBooksAsync( int count );
        List<BookModel> SearchBook( string title, string authorName );

        string GetAppName( );
    }
}
