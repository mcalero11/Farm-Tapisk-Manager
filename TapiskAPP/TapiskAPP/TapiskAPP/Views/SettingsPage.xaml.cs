using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TapiskAPP.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            date.ItemsSource = new List<string> { "USD","YEN","PSL","KON", };
        }

    }
}
