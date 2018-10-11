﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TapiskAPP.Services;
using TapiskAPP.Views;

namespace TapiskAPP.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
        readonly string UserIcon = "\uf007";
        readonly string SuccessIcon = "\uf00c";
        readonly Color UserColor = Color.DarkGray;
        readonly Color SuccessColor = Color.MediumSpringGreen;
        private string _iconTextProperty;

        public string IconTextProperty
        {
            get { return _iconTextProperty; }
            set { SetProperty(ref _iconTextProperty, value); }
        }

        private Color _iconColorProperty;

        public Color IconColorProperty
        {
            get { return _iconColorProperty; }
            set { SetProperty(ref _iconColorProperty, value); }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private string _user;

        public string Username
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _pass;

        public string Password
        {
            get { return _pass; }
            set { SetProperty(ref _pass, value); }
        }

        private IPageDialogService _dialogService { get; set; }
        private IStatusBarColorManager _statusBarColorManager { get; set; }

        public DelegateCommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, 
                                    IPageDialogService dialogService,
                                    IStatusBarColorManager statusBarColorManager) : base(navigationService)
        {
            _dialogService = dialogService;
            _statusBarColorManager = statusBarColorManager;
            _statusBarColorManager.SetColor(255,128,0,128);
            IconTextProperty = UserIcon;
            IconColorProperty = UserColor;

            LoginCommand = new DelegateCommand(Login);
        }

        private async void Login()
        {
            IsBusy = true;
            await Task.Delay(2000);
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                IconTextProperty = SuccessIcon;
                IconColorProperty = SuccessColor;
                IsBusy = false;
                await Task.Delay(600);
                await NavigationService.NavigateAsync(new Uri($"http://www.TapiskAPP.com/{nameof(MasterPage)}/{nameof(Xamarin.Forms.NavigationPage)}/{nameof(Views.MainPage)}", System.UriKind.Absolute));
                return;
            }
            IconTextProperty = UserIcon;
            IconColorProperty = UserColor;
            IsBusy = false;
            await _dialogService.DisplayAlertAsync("Problemas","Las credenciales son incorrectas","Aceptar");

        }
    }
}
