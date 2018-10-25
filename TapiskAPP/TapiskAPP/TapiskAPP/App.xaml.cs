using Prism;
using Prism.Ioc;
using TapiskAPP.ViewModels;
using TapiskAPP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using TapiskAPP.Views.MenuItemPages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TapiskAPP
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY3ODBAMzEzNjJlMzMyZTMwUUVQOUNCU2hxZGlTUElmLzhNTGJlNTUwZ3hxcUpwUjVyblJYM3BKM3cvcz0=");


            InitializeComponent();

            //await NavigationService.NavigateAsync($"{nameof(MasterPage)}/{nameof(NavigationPage)}/{nameof(Views.MainPage)}");
            await NavigationService.NavigateAsync($"{nameof(LoginPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage,MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterPage,MasterPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage,LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<UserPage,UserPageViewModel>();
            containerRegistry.RegisterForNavigation<CropPage,CropPageViewModel>();
            containerRegistry.RegisterForNavigation<HarvestPage,HarvestPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage,SettingsPageViewModel>();
        }
    }
}
