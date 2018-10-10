using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TapiskAPP.ViewModels
{
	public class UserPageViewModel : ViewModelBase
	{
        public UserPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
