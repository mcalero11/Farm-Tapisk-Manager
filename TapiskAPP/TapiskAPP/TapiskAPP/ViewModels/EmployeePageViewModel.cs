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
using TapiskAPP.Helpers;
using TapiskAPP.Models;
using TapiskAPP.Models.SqLiteModels;
using TapiskAPP.Services;
using TapiskAPP.Views.MenuItemPages;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class UserPageViewModel : ViewModelBase
	{
        #region Commands
        public Command<object> TapCommand { get; set; }
        public Command<object> HoldCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }

        #endregion

        #region Fields
        private IStatusBarColorManager _statusBarColorManager { get; set; }
        public IPageDialogService _dialogService { get; set; }
        public ISqLiteService _sqliteService { get; set; }
        private ObservableCollection<Empleado> _empleados;
        private bool _activity;

        

        #endregion

        #region Properties
        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set { SetProperty(ref _empleados, value); }
        }
        public bool Activity
        {
            get { return _activity; }
            set { SetProperty(ref _activity, value); }
        }
        #endregion

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
            
            Task.Run(async()=> { Activity=true; await fillUsers(); Activity = false; });
            TapCommand = new Command<object>(itemSelected);
            HoldCommand = new Command<object>(itemLongSelected);
            RefreshCommand = new Command(async() => await Refresh());
            DeleteCommand = new Command(async (o) => await Delete(o));
            AddCommand = new Command(async () => await NavigationService.NavigateAsync(nameof(NewEmployeePage)));
        }

        public async Task Delete(object obj)
        {
            var employee = (Empleado)obj;
            await HelperMethods.Delete(employee.Id,
                                       $"¿Estás seguro que deseas eliminar a {employee.Nombre}?",
                                       "employees",
                                       _dialogService);
        }
        
        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1500);
            await fillUsers();
            IsBusy = false;
        }

        private async Task fillUsers()
        {
            var response = await new RestService().GetList<Empleado>("employees");
            if (!response.IsSuccess)
            {
                await _dialogService.DisplayAlertAsync("Info", "Parece que hay problemas al intentar conectar con el servidor. Si el error persiste, contacte con soporte al cliente", "Aceptar");
                await NavigationService.GoBackAsync();
                return;
            }
            var list = (List<Empleado>)response.Result;
            if (list.Count == 0)
            {
                await _dialogService.DisplayAlertAsync("Info", "No se han encontrado datos", "Aceptar");
                return;
            }
            Empleados = new ObservableCollection<Empleado>(list);
        }

        private async void itemLongSelected(object obj)
        {
            var employee = (Empleado)(obj as Syncfusion.ListView.XForms.ItemHoldingEventArgs).ItemData;
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Employee", employee.Id);
            await NavigationService.NavigateAsync(nameof(NewEmployeePage), pairs);
        }

        private async void itemSelected(object obj)
        {
            var employee = (Empleado)(obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Employee",employee.Id);
            await NavigationService.NavigateAsync(nameof(DetailEmployeePage),pairs);
        }
    }
}
