using LgpDuvidas.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LgpDuvidas.ViewModels
{
    public class HistoryViewModel
    {
        public string Title { get; set; }
        public List<Message> Itens { get; set; }
        public HistoryViewModel()
        {
            Title = "History";
            Itens = new List<Message> { 
                new Message { Input = "teste", Output = "output" }, 
                new Message { Input = "teste", Output = "output" }, 
                new Message { Input = "teste", Output = "output" }, 
                new Message { Input = "teste", Output = "output" } 
            };
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}