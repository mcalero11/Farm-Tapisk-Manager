using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TapiskAPP.ViewModels
{
	public class CropPageViewModel : ViewModelBase
	{
        public CropPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Cultivos";
        }
    }
}
