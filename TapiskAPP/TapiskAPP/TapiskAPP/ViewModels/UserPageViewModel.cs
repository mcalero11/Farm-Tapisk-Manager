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
using TapiskAPP.Data;
using TapiskAPP.Models;
using TapiskAPP.Models.SqLiteModels;
using TapiskAPP.Services;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class UserPageViewModel : ViewModelBase
	{
        private IStatusBarColorManager _statusBarColorManager { get; set; }
        public IPageDialogService _dialogService { get; set; }
        public ISqLiteService _sqliteService { get; set; }
        private ObservableCollection<Empleado> _empleados;
        public Command<object> TapCommand { get; set; }
        public Command<object> HoldCommand { get; set; }



        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set { SetProperty(ref _empleados, value); }
        }

        private ObservableCollection<User> _sqliteUserJ;

        public ObservableCollection<User> SqliteUser
        {
            get { return _sqliteUserJ; }
            set { SetProperty(ref _sqliteUserJ, value); }
        }


        public UserPageViewModel(INavigationService navigationService,
                                    IStatusBarColorManager statusBarColorManager,
                                    IPageDialogService dialogService,
                                    ISqLiteService sqLiteService) : base(navigationService)
        {
            Title = "Empleados";
            _statusBarColorManager = statusBarColorManager;
            _statusBarColorManager.SetColor(155,0,255,1);
            _dialogService = dialogService;
            _sqliteService = sqLiteService;

            Empleados = new ObservableCollection<Empleado>(MockEmpleados.GetEmpleados());
            Task.Run(()=> GetSqliteUsers());
            TapCommand = new Command<object>(itemSelected);
            HoldCommand = new Command<object>(itemLongSelected);
        }

        private async Task GetSqliteUsers()
        {

            var sqliteUsers = await new SqLiteService(_sqliteService).GetUsers();
            SqliteUser = new ObservableCollection<User>(sqliteUsers);
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
