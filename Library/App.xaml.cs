using System;
using Library.Contracts;
using Library.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library
{
    public partial class App : Application
    {
        public static string GoogleApiUrl = "https://www.googleapis.com/books/v1";

        public App()
        {
            InitializeComponent();

            RegisterServices();

            MainPage = new NavigationPage(new Home());
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

        private void RegisterServices()
        {
            DependencyService.Register<IBookService,BookService>();
        }
    }
}
