using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using TapiskAPP.Services;

namespace TapiskAPP.ViewModels
{
	public class UserPageViewModel : ViewModelBase
	{
        private IStatusBarColorManager _statusBarColorManager { get; set; }
        public UserPageViewModel(INavigationService navigationService,
                                    IStatusBarColorManager statusBarColorManager) : base(navigationService)
        {
            Title = "Empleados";
            _statusBarColorManager = statusBarColorManager;
            _statusBarColorManager.SetColor(155,0,255,1);
        }
    }
}
