using System;
using Xamarin.Forms;

namespace Library.Controls
{
    public class PdfWebView : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(propertyName: "Uri",
             returnType: typeof(string),
             declaringType: typeof(PdfWebView),
             defaultValue: default(string),
             propertyChanged: UriPropertyChanged);

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        static void UriPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newUri = (string)newValue;
        }
    }
}
