using System;

namespace Munchin.BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int TotalPage { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
