using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TapiskAPP.Models;

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
        public MenuItem SelectedItem { get; set; }

        public DelegateCommand ItemTappedCommand { get; set; }
        public DelegateCommand HomeCommand { get; set; }
        public DelegateCommand SettingsCommand { get; set; }

        public MasterPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            MenuItems = new ObservableCollection<MenuItem>(MockMenuItems.GetMenuItems());
            _dialogService = dialogService;
            ItemTappedCommand = new DelegateCommand(ItemTap);
            SettingsCommand = new DelegateCommand(GoToSettingsPage);
            HomeCommand = new DelegateCommand(GoToHomePage);
        }

        private void ItemTap()
        {
            //use SelectedItem Property
            _dialogService.DisplayAlertAsync("Navegar", $"Go to {SelectedItem.PageName}", "Ok");
        }
        private void GoToSettingsPage()
        {
            _dialogService.DisplayAlertAsync("Navegar","Go to Settings","Ok");
        }

        private void GoToHomePage()
        {
            _dialogService.DisplayAlertAsync("Navegar","Go to Home","Ok");
        }
    }
}
