using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Library.Controls;
using Android.Content;
using Library.Droid.Renders;
using System.Net;

[assembly: ExportRenderer(typeof(PdfWebView), typeof(PdfWebViewRenderer))]
namespace Library.Droid.Renders
{
    public class PdfWebViewRenderer : WebViewRenderer
    {
        public PdfWebViewRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customWebView = Element as PdfWebView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl($"file:///android_asset/Content/{((PdfWebView)Element).Uri}");

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var customWebView = Element as PdfWebView;

            if (customWebView != null && e.PropertyName == nameof(PdfWebView.Uri))
            {
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", customWebView.Uri));
            }
        }
    }

}
