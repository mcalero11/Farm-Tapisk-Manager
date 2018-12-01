using System;
using TapiskAPP.Models;
using TapiskAPP.ViewModels;
using Xamarin.Forms;

namespace TapiskAPP.Views.MenuItemPages
{
    public partial class CropPage : ContentPage
    {
        public CropPage()
        {
            InitializeComponent();
        }
        private object item { get; set; }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (item != null && item is Cultivo)
            {
                (BindingContext as CropPageViewModel).DeleteCommand.Execute(item);
            }
        }

        private void Listcrop_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            item = e.ItemData;
        }
    }
}
