using Plugin.SharedTransitions;
using Xamarin.Forms;

namespace Coffeeffee
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "Shapes_Experimental" });

            MainPage = new SharedTransitionNavigationPage(new MainPage());
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
