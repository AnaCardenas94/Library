using System;
using System.Collections.Generic;
using Library.ViewModels;
using Xamarin.Forms;

namespace Library
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}
