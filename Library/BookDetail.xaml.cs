using System;
using System.Collections.Generic;
using Library.Models;
using Library.ViewModels;
using Xamarin.Forms;

namespace Library
{
    public partial class BookDetail : ContentPage
    {
        public BookDetail(Item item)
        {
            InitializeComponent();
            BindingContext = new BookDetailViewModel(item);
        }
    }
}
