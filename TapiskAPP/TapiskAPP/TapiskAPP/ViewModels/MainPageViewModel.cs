using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TapiskAPP.Services;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        IStatusBarColorManager _statusBarColorManager { get; set; }

        public MainPageViewModel(INavigationService navigationService, IStatusBarColorManager statusBarColorManager)
            : base(navigationService)
        {
            Title = "Home";
            _statusBarColorManager = statusBarColorManager;
            _statusBarColorManager.SetColor(255, 139, 0, 0);
        }
    }
}
