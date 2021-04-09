using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Models;
using Xamarin.Forms;

namespace Library.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private string _book;

        public string Book { get => _book; set => SetProperty(ref _book, value); }

        public ICommand SearchCommand
        {
            get => new Command( () =>  Search(new Book() { bookName = Book }));
        }

        public async void Search(Book book)

        {
            if(!string.IsNullOrEmpty(Book.Trim()))
                await Application.Current.MainPage.Navigation.PushAsync(new Books(book));

            else
                await Application.Current.MainPage.DisplayAlert("Attention", "You must enter a book", "OK");
        }
    }
}


