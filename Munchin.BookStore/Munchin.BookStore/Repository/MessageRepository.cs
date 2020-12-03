using Microsoft.Extensions.Options;
using Munchin.BookStore.Models;

namespace Munchin.BookStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertconfiguration;

        public MessageRepository( IOptionsMonitor<NewBookAlertConfig> newBookAlertconfiguration )
        {
            _newBookAlertconfiguration = newBookAlertconfiguration;
            //newBookAlertconfiguration.OnChange( config =>
            // {
            //     _newBookAlertconfiguration = config;
            // } );

        }
        public string GetName( )
        {
            return _newBookAlertconfiguration.CurrentValue.BookName;
        }
    }
}
