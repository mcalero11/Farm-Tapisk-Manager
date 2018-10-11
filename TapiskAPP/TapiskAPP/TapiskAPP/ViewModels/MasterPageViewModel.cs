using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TapiskAPP.Models;
using TapiskAPP.Services;
using TapiskAPP.Views;

namespace TapiskAPP.ViewModels
{
	public class MasterPageViewModel : ViewModelBase
	{
        private ObservableCollection<MenuItem> _menuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }
        private IPageDialogService _dialogService { get; set; }
        private IStatusBarColorManager _statusBarColorManager { get; set; }
        public MenuItem SelectedItem { get; set; }

        public DelegateCommand ItemTappedCommand { get; set; }
        public DelegateCommand HomeCommand { get; set; }
        public DelegateCommand SettingsCommand { get; set; }

        public MasterPageViewModel(INavigationService navigationService, 
                                    IPageDialogService dialogService,
                                    IStatusBarColorManager statusBarColorManager) : base(navigationService)
        {
            MenuItems = new ObservableCollection<MenuItem>(MockMenuItems.GetMenuItems());
            _dialogService = dialogService;
            _statusBarColorManager = statusBarColorManager;
            ItemTappedCommand = new DelegateCommand(ItemTap);
            SettingsCommand = new DelegateCommand(GoToSettingsPage);
            HomeCommand = new DelegateCommand(GoToHomePage);

            _statusBarColorManager.SetColor(255,139,0,0);
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
