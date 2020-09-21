using LgpDuvidas.Data;
using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using LgpDuvidas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LgpDuvidas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public IAuthService _authService => DependencyService.Get<IAuthService>();
        private AuthModel UserModel { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            UserModel = new AuthModel();
        }

        private void Login(object sender, EventArgs e)
        {
            var authRequest = _authService.Login(UserModel);
            authRequest.Wait();

            UserModel = authRequest.Result;

            if (string.IsNullOrWhiteSpace(UserModel.Token))
            {

            }
            Shell.Current.GoToAsync("//ChatPage").Wait();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserModel.user = e.NewTextValue;
        }

        private void Pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserModel.pass = e.NewTextValue;
        }
    }
}