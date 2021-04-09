using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Library.Controls;
using Library.Models;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Library.ViewModels
{
    public class BookDetailViewModel : BaseViewModel
    {
        private string thumbnail;
        private string title;
        private string subtitle;
        private string publishDateFormat;
        public string description;
        public ObservableCollection<string> authors;
        private string uri;


        public string Thumbnail { get => thumbnail; set => SetProperty(ref thumbnail, value); }
        public string Title { get => title; set => SetProperty(ref title, value); }
        public string Subtitle { get => subtitle; set => SetProperty(ref subtitle, value); }
        public string PublishDateFormat { get => publishDateFormat; set => SetProperty(ref publishDateFormat, value); }
        public string Description { get => description; set => SetProperty(ref description, value); }
        public ObservableCollection<string> Authors { get => authors; set => SetProperty(ref authors, value); }

        public ICommand ReadCommand
        {
            get => new Command(async () => await Application.Current.MainPage.Navigation.PushPopupAsync(new PopUpPDF(uri)) );
        }


        public BookDetailViewModel(Item item)
        {
            Thumbnail = item.VolumeInfo.ImageLinks.Thumbnail.ToString();
            Title = item.VolumeInfo.Title;
            Subtitle = item.VolumeInfo.Subtitle;
            PublishDateFormat = item.VolumeInfo.PublishDateFormat;
            Description = item.VolumeInfo.Description;
            Authors = new ObservableCollection<string>(item.VolumeInfo.Authors);
            uri = item.AccessInfo.WebReaderLink;
        }
    }
}




