using Xamarin.Forms;

namespace TapiskAPP.Views.MenuItemPages
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            listEmployee.SelectionController = new Controls.SelectionListItem(listEmployee);
        }
    }
}
