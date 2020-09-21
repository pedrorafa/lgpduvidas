using LgpDuvidas.Data;
using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LgpDuvidas.ViewModels
{
    public class HistoryViewModel
    {
        private IAnalyticsService _analyticsService => DependencyService.Get<IAnalyticsService>();
        public string Title { get; set; }
        public List<Message> Itens { get; set; }
        public HistoryViewModel()
        {
            var task = _analyticsService.GetMessages();
            task.Wait();
            var items = task.Result;
            if(items != null)
                Itens = items.ToList();

            Title = "History";
        }
    }
}