using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ApiCat.Views;
using ApiCat.Service;

namespace ApiCat
{
    public partial class App : Application
    {
        public static EntryManager CountManager { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Page1());
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
