using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TapiskAPP.Helpers;
using TapiskAPP.Models;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class NewEmployeePageViewModel : ViewModelBase, INavigatedAware
	{
        #region Commands

        public Command DeleteCommand { get; set; }
        #endregion
        #region Fields
        private Empleado _empleado;
        private IPageDialogService _dialogService { get; set; }

        #endregion
        #region Properties
        public Empleado Empleado
        {
            get { return _empleado; }
            set { SetProperty(ref _empleado, value); }
        }

        #endregion
        #region Constructors
        public NewEmployeePageViewModel(INavigationService navigationService,
                                        IPageDialogService dialogService) : base(navigationService)
        {
            DeleteCommand = new Command(async ()=> await HelperMethods.Delete(Empleado.Id,
                                                                              $"¿Estás seguro que deseas eliminar a {Empleado.Nombre}?",
                                                                              "employees",
                                                                              _dialogService));
        }


        #endregion
        #region Methods
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
