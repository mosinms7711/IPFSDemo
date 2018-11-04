using System;
using System.Diagnostics;
using System.IO;
using NethereumWithTraditionalMVVM.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NethereumWithTraditionalMVVM
{
    public partial class App : Application
    {
        WalletConfigurationService walletConfiguration = new WalletConfigurationService();

        public static string HexString = null;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            /*if (walletConfiguration.IsConfigured())
            {
                MainPage = new DashboardPage();
                Debug.WriteLine("DashBoard Called");
            }
            else
            {
                MainPage = new MainPage();
            }*/
        }

        protected override void OnStart()
        {
            HexString = null;
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
