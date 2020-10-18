using LgpDuvidas.Models;
using System.Collections.Generic;
using System.Linq;

namespace LgpDuvidas.ViewModels
{
    public class MessagesViewModel
    {
        public string Title { get; set; }
        public List<Message> Messages { get; set; }
        public MessagesViewModel(IEnumerable<Message> messages)
        {
            Title = "Messages";
            Messages = messages.ToList();
        }
        public void OnAppearing()
        {

        }
    }
}