using System;
using Library.Models;
using Library.Contracts;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {

        private readonly IBookService _bookService = DependencyService.Get<IBookService>();
        private string bookName;
        private ObservableCollection<Item> items;
        private int itemTreshold;
        private bool isBusy;


        public ObservableCollection<Item> Items { get => items; set => SetProperty(ref items, value); }
        public int ItemTreshold { get => itemTreshold; set => SetProperty(ref itemTreshold, value); }
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }


        public ICommand BookDetailCommand
        {
            get => new Command<Item>((m) => BookDetail(m));
        }


        public ICommand ReachedCommand
        {
            get => new Command(async() => await ReachedAsync());
        }

        public BooksViewModel(Book book)
        {
            GetBooks(book);
        }

        public async void GetBooks(Book book)

        {
            IsBusy = true;
            bookName = book.bookName;
            BookByPagination bookByPagination = new BookByPagination();
            bookByPagination.bookName = book.bookName;
            bookByPagination.startIndex = "0";
            bookByPagination.maxResults = "20";
            var response = await _bookService.GetBooksByPagination(bookByPagination);
            if (response.Items != null && response.Items.Count() > 0)
            {
                Items = new ObservableCollection<Item>(response.Items);
            }
            else
                await Application.Current.MainPage.DisplayAlert("Without results",string.Format("No results found"),"OK");
            IsBusy = false;
        }


        private async Task ReachedAsync()
        {
            IsBusy = true;
            BookByPagination bookByPagination = new BookByPagination();
            bookByPagination.bookName =  bookName;
            bookByPagination.startIndex = Items.Count().ToString();
            bookByPagination.maxResults = "20";
           

            var newResponse = await _bookService.GetBooksByPagination(bookByPagination);

            
                    if (newResponse.Items != null)
                    {
                        foreach (var item in newResponse.Items)
                        {
                            Items.Add(item);
                        }
                    }
                    else
                    {
                        ItemTreshold = -1;
                    }
            IsBusy = false;


        }

        public async void BookDetail(Item detail)

        {
            await Application.Current.MainPage.Navigation.PushAsync(new BookDetail(detail));
        }

    }
}
