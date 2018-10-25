using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TapiskAPP.Models;
using TapiskAPP.Services;

namespace TapiskAPP.ViewModels
{
	public class UserPageViewModel : ViewModelBase
	{
        private IStatusBarColorManager _statusBarColorManager { get; set; }
        private ObservableCollection<Empleado> _empleados;

        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set { SetProperty(ref _empleados, value); }
        }

        public UserPageViewModel(INavigationService navigationService,
                                    IStatusBarColorManager statusBarColorManager) : base(navigationService)
        {
            Title = "Empleados";
            _statusBarColorManager = statusBarColorManager;
            _statusBarColorManager.SetColor(155,0,255,1);

            Empleados = new ObservableCollection<Empleado>(MockEmpleados.GetEmpleados());
        }
    }
}
