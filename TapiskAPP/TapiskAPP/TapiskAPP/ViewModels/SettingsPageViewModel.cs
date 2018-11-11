using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TapiskAPP.Services;
using Xamarin.Forms;

namespace TapiskAPP.ViewModels
{
	public class SettingsPageViewModel : ViewModelBase
	{
        public Command Logout { get; set; }

        private ISqLiteService _sqLiteService { get; set; }
        private IPageDialogService _dialogPage { get; set; }

        public SettingsPageViewModel(INavigationService navigationService,
                                     ISqLiteService sqLiteService,
                                     IPageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Configuraciones";
            _sqLiteService = sqLiteService;
            _dialogPage = pageDialogService;
            Logout = new Command(async()=>await ClearLogin());
        }

        private async Task ClearLogin()
        {
            var sqlite = new Data.SqLiteService(_sqLiteService);
            var num = await sqlite.Logout();
            await _dialogPage.DisplayAlertAsync("Info",$"{num} removes","Ok");
        }
    }
}
