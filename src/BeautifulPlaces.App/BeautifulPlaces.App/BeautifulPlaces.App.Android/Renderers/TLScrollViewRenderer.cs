using Xamarin.Forms;
using BeautifulPlaces.App.Controls;
using BeautifulPlaces.App.Renderers;
#if ANDROID
using Xamarin.Forms.Platform.Android;
#elif IOS
using Xamarin.Forms.Platform.iOS;
#endif

[assembly: ExportRenderer(typeof(TLScrollView), typeof(TLScrollViewRenderer))]

namespace BeautifulPlaces.App.Renderers
{
    public class TLScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var element = e.NewElement as TLScrollView;
            element?.Render();
        }
    }
}