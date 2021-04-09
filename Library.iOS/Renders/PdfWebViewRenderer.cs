using System.ComponentModel;
using Foundation;
using Library.Controls;
using Library.iOS.Renders;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PdfWebView), typeof(PdfWebViewRenderer))]
namespace Library.iOS.Renders
{
    public class PdfWebViewRenderer : ViewRenderer<PdfWebView, WKWebView>
    {
        WKWebView _wkWebView;
        protected override void OnElementChanged(ElementChangedEventArgs<PdfWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var config = new WKWebViewConfiguration();
                _wkWebView = new WKWebView(Frame, config);
                SetNativeControl(_wkWebView);
            }
            if (e.NewElement != null)
            {
                Control.LoadRequest(new NSUrlRequest(new NSUrl(Element.Uri)));
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                var customWebView = Element as PdfWebView;
                string url = customWebView.Uri;
                Control.LoadRequest(new NSUrlRequest(new NSUrl(url)));
            }
        }
    }
}
