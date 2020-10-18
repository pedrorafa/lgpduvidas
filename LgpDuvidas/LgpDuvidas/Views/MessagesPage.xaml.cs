using LgpDuvidas.Models;
using LgpDuvidas.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LgpDuvidas.Views
{
    public partial class MessagesPage : ContentPage
    {
        MessagesViewModel vm;
        public MessagesPage(IEnumerable<Message> messages)
        {
            BindingContext = vm = new MessagesViewModel(messages);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }
    }
}