using Microsoft.AspNetCore.Mvc;
using Munchin.BookStore.Repository;
using System.Threading.Tasks;

namespace Munchin.BookStore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly IBookRepositry _bookRepositry;

        public TopBooksViewComponent( IBookRepositry bookRepositry )
        {
            _bookRepositry = bookRepositry;
        }
        public async Task<IViewComponentResult> InvokeAsync( int count )
        {
            var books = await _bookRepositry.GetTopBooksAsync( count );
            return View( books );
        }
    }
}
