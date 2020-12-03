using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Munchin.BookStore.Models;
using Munchin.BookStore.Repository;

namespace Munchin.BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IMessageRepository _messageRepository;

        public HomeController( IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration,
                               IMessageRepository messageRepository )
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Get( "InternalBook" );
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get( "ThirdPartyBook" );
            _messageRepository = messageRepository;
        }
        public ViewResult Index( )
        {
            bool IsDisplay = _newBookAlertconfiguration.DisplayNewBookAlert;
            bool IsDisplay1 = _thirdPartyBookconfiguration.DisplayNewBookAlert;

            //var value = _messageRepository.GetName();

            //var newBook = configuration.GetSection( "NewBookAlert" );
            //var result = newBook.GetValue<bool>( "DisplayNewBookAlert" );
            //var bookName = newBook.GetValue<string>( "BookName" );

            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3obj1"];
            return View();
        }

        public ViewResult AboutUs( string name )
        {
            return View();
        }
        public ViewResult ContactUs( )
        {
            return View();
        }
    }
}
