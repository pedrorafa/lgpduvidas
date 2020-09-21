using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LgpDuvidas.ViewModels
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        public IAuthService _authService => DependencyService.Get<IAuthService>();
        public AuthModel UserModel { get; set; }

        public bool IsLoading { get; set; }
        public bool HasError { get; set; }
        public ICommand Login { get; }

        public LoginPageViewModel()
        {
            IsLoading = false;
            HasError = false;
            UserModel = new AuthModel();

            Login = new Command(OnLogin);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnAppearing()
        {
            IsLoading = false;
            HasError = false;
        }

        private async void OnLogin()
        {
            IsLoading = true;
            var authRequest = await _authService.Login(UserModel);
            UserModel = authRequest;

            if (string.IsNullOrWhiteSpace(UserModel.Token))
            {
                IsLoading = false;
                HasError = true;
                return;
            }
            await Shell.Current.GoToAsync("//ChatPage");
            IsLoading = false;
        }
        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
    }
}