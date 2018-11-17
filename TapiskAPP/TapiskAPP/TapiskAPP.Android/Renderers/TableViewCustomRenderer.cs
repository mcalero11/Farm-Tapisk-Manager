using Android.Content;
using TapiskAPP.Controls;
using TapiskAPP.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TableViewControl), typeof(TableViewCustomRenderer))]
namespace TapiskAPP.Droid.Renderers
{
    public class TableViewCustomRenderer : TableViewRenderer
    {
        public TableViewCustomRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var listView = Control as global::Android.Widget.ListView;
            listView.DividerHeight = 0;
        }
    }
}