using LgpDuvidas.Data;
using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using LgpDuvidas.Views;
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
        public IAuthService _authService => DependencyService.Get<IAuthService>();
        public bool Loading { get; set; }
        public string Title { get; set; }
        public List<Entity> Itens { get; set; }
        public ICommand OpenEntity { get; }
        public HistoryViewModel()
        {
            Title = "History";
            OpenEntity = new Command(OnOpenEntity);
        }

        public void OnAppearing()
        {
            Loading = true;
            LoadMessages();
        }

        public async void LoadMessages()
        {
            int erroCount = 0;
            var items = await _analyticsService.GetMessages();
            while (items == null && erroCount < 2)
            {
                erroCount++;
                await _authService.Refresh();
                items = await _analyticsService.GetMessages();
            }
            if (items != null)
                Itens = items.ToList();
            Loading = false;
        }

        private async void OnOpenEntity()
        {
            var page = new MessagesPage(Itens[0].Messages.ToList());
            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}