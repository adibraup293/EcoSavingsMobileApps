using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcoSavingsMobileApps.Views;

namespace EcoSavingsMobileApps
{
    public partial class App : Application
    {
        public static string Username { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInView());
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
