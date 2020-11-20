using Munchin.BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Munchin.BookStore.Repository
{
    public class BookRepositry
    {
        public List<BookModel> GetAllBooks( )
        {
            return DataSource();
        }

        public BookModel GetBookById( int id )
        {
            return DataSource().Where( x => x.Id == id ).FirstOrDefault();
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
