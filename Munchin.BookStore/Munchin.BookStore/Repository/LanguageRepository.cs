using Microsoft.EntityFrameworkCore;
using Munchin.BookStore.Data;
using Munchin.BookStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munchin.BookStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepository( BookStoreContext context )
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages( )
        {
            return await _context.Language.Select( x => new LanguageModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name

            } ).ToListAsync();
        }

    }
}
