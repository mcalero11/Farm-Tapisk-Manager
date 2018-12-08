using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TapiskAPP.Data;
using TapiskAPP.Helpers;
using TapiskAPP.Models;
using TapiskAPP.Services;
using TapiskAPP.Views.MenuItemPages;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class CropPageViewModel : ViewModelBase
	{
        #region Commands
        public Command<object> TapCommand { get; set; }
        public Command<object> HoldCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command AddCommand { get; set; }
        #endregion
        #region Fields
        public IPageDialogService _dialogService { get; set; }
        public ISqLiteService _sqliteService { get; set; }
        private ObservableCollection<Cultivo> _cultivos;
        private bool _activity;
        #endregion
        #region Properties
        public ObservableCollection<Cultivo> Cultivos
        {
            get { return _cultivos; }
            set { SetProperty(ref _cultivos, value); }
        }
        public bool Activity
        {
            get { return _activity; }
            set { SetProperty(ref _activity, value); }
        }
        #endregion
        #region Constructors
        public CropPageViewModel(INavigationService navigationService,
                                 IPageDialogService dialogService,
                                 ISqLiteService sqLiteService) : base(navigationService)
        {
            Title = "Cultivos";
            _dialogService = dialogService;
            _sqliteService = sqLiteService;
            Task.Run(async () => { Activity = true; await fillCultivos(); Activity = false; });
            TapCommand = new Command<object>(itemSelected);
            HoldCommand = new Command<object>(itemLongSelected);
            RefreshCommand = new Command(async () => await Refresh());
            DeleteCommand = new Command(async (o) => await Delete(o));
            AddCommand = new Command(async () => await NavigationService.NavigateAsync(nameof(NewEmployeePage)));
        }
        #endregion
        #region Methods
        private async Task fillCultivos()
        {
            var response = await new RestService().GetList<Cultivo>("crops");
            if (!response.IsSuccess)
            {
                await _dialogService.DisplayAlertAsync("Info", "Parece que hay problemas al intentar conectar con el servidor. Si el error persiste, contacte con soporte al cliente", "Aceptar");
                await NavigationService.GoBackAsync();
                return;
            }
            var list = (List<Cultivo>)response.Result;
            if (list.Count == 0)
            {
                await _dialogService.DisplayAlertAsync("Info", "No se han encontrado datos", "Aceptar");
                return;
            }
            Cultivos = new ObservableCollection<Cultivo>(list);
        }

        public async Task Delete(object obj)
        {
            var employee = (Empleado)obj;
            await HelperMethods.Delete(employee.Id,
                                       $"¿Estás seguro que deseas eliminar a {employee.Nombre}?",
                                       "employees",
                                       _dialogService);
        }
        private async void itemLongSelected(object obj)
        {
            var cultivo = (Cultivo)(obj as Syncfusion.ListView.XForms.ItemHoldingEventArgs).ItemData;
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Cultivo", cultivo.Id);
            await NavigationService.NavigateAsync(nameof(NewCropPage), pairs);
        }

        private async void itemSelected(object obj)
        {
            var cultivo = (Cultivo)(obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData;
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Cultivo", cultivo.Id);
            await NavigationService.NavigateAsync(nameof(DetailCropPage), pairs);
        }
        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1500);
            await fillCultivos();
            IsBusy = false;
        }
        #endregion


    }
}
