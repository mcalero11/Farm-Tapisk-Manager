using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TapiskAPP.Models;
using TapiskAPP.Models.SqLiteModels;
using TapiskAPP.Services;
using TapiskAPP.Views;

namespace TapiskAPP.ViewModels
{
	public class MasterPageViewModel : ViewModelBase
	{
        User _user;
        private ObservableCollection<MenuItem> _menuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }
        public string Nombres
        {
            get { return $"{_user.Name} {_user.LastName}"; }
        }
        public string Cargo
        {
            get;
        }

        private IPageDialogService _dialogService { get; set; }
        private IStatusBarColorManager _statusBarColorManager { get; set; }
        private ISqLiteService _sqLiteService { get; set; }
        public MenuItem SelectedItem { get; set; }

        public DelegateCommand ItemTappedCommand { get; set; }
        public DelegateCommand HomeCommand { get; set; }
        public DelegateCommand SettingsCommand { get; set; }

        public MasterPageViewModel(INavigationService navigationService, 
                                    IPageDialogService dialogService,
                                    IStatusBarColorManager statusBarColorManager,
                                    ISqLiteService sqLiteService) : base(navigationService)
        {
            _sqLiteService = sqLiteService;
            MenuItems = new ObservableCollection<MenuItem>(MockMenuItems.GetMenuItems());
            Task.Run(()=> GetUserData());
            _dialogService = dialogService;
            _statusBarColorManager = statusBarColorManager;
            ItemTappedCommand = new DelegateCommand(ItemTap);
            SettingsCommand = new DelegateCommand(GoToSettingsPage);
            HomeCommand = new DelegateCommand(GoToHomePage);

            _statusBarColorManager.SetColor(255,139,0,0);
        }

        private async Task GetUserData()
        {
            var user = await new Data.SqLiteService(_sqLiteService).RetrieveUser();
            _user = user != null ? user : new User();
        }

        private void ItemTap()
        {
            NavigationService.NavigateAsync($"{nameof(Xamarin.Forms.NavigationPage)}/{SelectedItem.PageName}");
        }
        private void GoToSettingsPage()
        {
            NavigationService.NavigateAsync($"{nameof(Xamarin.Forms.NavigationPage)}/{nameof(SettingsPage)}");
        }

        private void GoToHomePage()
        {
            NavigationService.NavigateAsync($"{nameof(Xamarin.Forms.NavigationPage)}/{nameof(MainPage)}");
        }
    }
}
