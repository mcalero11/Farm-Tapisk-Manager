using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TapiskAPP.Controls
{
    public class SelectionListItem : SelectionController
    {
        public SelectionListItem(SfListView listView) : base(listView)
        {
        }

        protected override void AnimateSelectedItem(ListViewItem selectedListViewItem)
        {
            base.AnimateSelectedItem(selectedListViewItem);
            selectedListViewItem.Opacity = 0.05;
            selectedListViewItem.FadeTo(1, 3000, Easing.SinInOut);
        }
    }
}
