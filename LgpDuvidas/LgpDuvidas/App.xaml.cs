using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LgpDuvidas.Services;
using LgpDuvidas.Views;

namespace LgpDuvidas
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<WatsonAssistantService>();
            MainPage = new AppShell();
            Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
