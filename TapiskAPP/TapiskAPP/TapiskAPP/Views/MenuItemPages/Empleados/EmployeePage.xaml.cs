using System;
using System.Threading.Tasks;
using TapiskAPP.Models;
using TapiskAPP.ViewModels;
using Xamarin.Forms;

namespace TapiskAPP.Views.MenuItemPages
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            //listEmployee.SelectionController = new Controls.SelectionListItem(listEmployee);
            
        }
        private object item { get; set; }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (item != null && item is Empleado)
            {
                (BindingContext as UserPageViewModel).DeleteCommand.Execute(item);
            }
        }

        private void ListEmployee_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            item = e.ItemData;
        }
    }
}
