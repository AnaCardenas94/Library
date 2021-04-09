using System;
using System.Collections.Generic;
using Library.Models;
using Library.ViewModels;
using Xamarin.Forms;

namespace Library
{
    public partial class Books : ContentPage
    {
        public Books(Book book)
        {
            InitializeComponent();
            BindingContext = new BooksViewModel(book);
        }
    }
}
