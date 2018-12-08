using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TapiskAPP.Data;
using TapiskAPP.Helpers;
using TapiskAPP.Models;
using TapiskAPP.Views.MenuItemPages;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class DetailEmployeePageViewModel : ViewModelBase , INavigatedAware
	{
        #region Commands
        public Command EditCommand { get; set; }
        public Command DeleteCommand { get; set; }

        #endregion
        #region Fields
        private IPageDialogService _dialogService { get; set; }
        private Empleado _empleado;
        #endregion
        #region Properties
        public Empleado Empleado
        {
            get { return _empleado; }
            set { SetProperty(ref _empleado, value); }
        }
        #endregion
        #region Constructors
        public DetailEmployeePageViewModel(INavigationService navigationService,
                                            IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            Title = "Detail";
            EditCommand = new Command(EditItem);
            DeleteCommand = new Command(async ()=> await HelperMethods.Delete(Empleado.Id,
                                                                              $"¿Estás seguro que deseas eliminar a {Empleado.Nombre}?",
                                                                              "employees",
                                                                              _dialogService));
        }

        #endregion
        #region Methods
        

        private async void EditItem()
        {
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Employee", Empleado);
            await NavigationService.NavigateAsync(nameof(NewEmployeePage), pairs);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var employee = parameters.GetValue<Empleado>("Employee");
            Empleado = employee ?? new Empleado();
        }



        #endregion

    }
}
