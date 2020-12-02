using Munchin.BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munchin.BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages( );
    }
}