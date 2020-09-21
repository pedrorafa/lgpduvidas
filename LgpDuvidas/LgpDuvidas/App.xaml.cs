using LgpDuvidas.Data;
using LgpDuvidas.Services;
using Xamarin.Forms;

namespace LgpDuvidas
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<WatsonAssistantService>();
            DependencyService.Register<AnalyticsService>();

            DependencyService.Register<AuthService>();
            DependencyService.Register<DbContext>();

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
