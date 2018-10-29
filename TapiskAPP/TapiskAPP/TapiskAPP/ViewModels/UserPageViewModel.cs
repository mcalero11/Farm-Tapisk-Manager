using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TapiskAPP.Models;
using TapiskAPP.Services;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class UserPageViewModel : ViewModelBase
	{
        private IStatusBarColorManager _statusBarColorManager { get; set; }
        public IPageDialogService _dialogService { get; set; }
        private ObservableCollection<Empleado> _empleados;
        public Command<object> TapCommand { get; set; }
        public Command<object> HoldCommand { get; set; }



        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set { SetProperty(ref _empleados, value); }
        }

        public UserPageViewModel(INavigationService navigationService,
                                    IStatusBarColorManager statusBarColorManager,
                                    IPageDialogService dialogService) : base(navigationService)
        {
            Title = "Empleados";
            _statusBarColorManager = statusBarColorManager;
            _statusBarColorManager.SetColor(155,0,255,1);
            _dialogService = dialogService;

            Empleados = new ObservableCollection<Empleado>(MockEmpleados.GetEmpleados());
            TapCommand = new Command<object>(itemSelected);
            HoldCommand = new Command<object>(itemLongSelected);
        }

        private void itemLongSelected(object obj)
        {
            var employee = (Empleado)(obj as Syncfusion.ListView.XForms.ItemHoldingEventArgs).ItemData;
            _dialogService.DisplayAlertAsync("Info",employee.Apellido,"Ok");
        }

        private async void itemSelected(object obj)
        {
            await Task.Delay(3000);
            var employee = (Empleado)(obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            await _dialogService.DisplayAlertAsync("Info",$"{employee.Nombre}","OK");
        }
    }
}
