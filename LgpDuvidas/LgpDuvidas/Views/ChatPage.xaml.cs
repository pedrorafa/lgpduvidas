using LgpDuvidas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LgpDuvidas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        ChatViewModel vm;

        public ChatPage()
        {
            InitializeComponent();

            BindingContext = vm = new ChatViewModel();

            vm.Messages.CollectionChanged += (sender, e) =>
            {
                var target = vm.Messages[vm.Messages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }
    }
}