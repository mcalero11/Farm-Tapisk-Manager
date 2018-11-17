using Prism.Navigation;
using Prism.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TapiskAPP.Services;
using TapiskAPP.Views;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class SettingsPageViewModel : ViewModelBase
	{
        public Command Logout { get; set; }
        public Command OpenPickerCommand { get; set; }

        private ISqLiteService _sqLiteService { get; set; }
        private IPageDialogService _dialogPage { get; set; }

        private bool _isPickerOpen;

        public bool IsPickerOpen
        {
            get { return _isPickerOpen; }
            set { SetProperty(ref _isPickerOpen, value); }
        }

        private string _itemPickerSelected;

        public string ItemPickerSelected
        {
            get { return _itemPickerSelected; }
            set { SetProperty(ref _itemPickerSelected, value); }
        }


        public SettingsPageViewModel(INavigationService navigationService,
                                     ISqLiteService sqLiteService,
                                     IPageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Configuraciones";
            _sqLiteService = sqLiteService;
            _dialogPage = pageDialogService;
            Logout = new Command(async()=>await ClearLogin());
            OpenPickerCommand = new Command(()=>IsPickerOpen = true);
        }

        private async Task ClearLogin()
        {
            var accept = await  _dialogPage.DisplayAlertAsync("Alerta","¿Estás seguro que deseas cerrar sesión?","Salir","Cancelar");
            if (accept)
            {
                var sqlite = new Data.SqLiteService(_sqLiteService);
                var num = await sqlite.Logout();
                Debug.WriteLine($"Se han eliminado {num} registros");
                await NavigationService.NavigateAsync(new Uri("http://www.TapiskAPP.com/" + nameof(LoginPage), System.UriKind.Absolute), animated: true);
            }
        }
    }
}
