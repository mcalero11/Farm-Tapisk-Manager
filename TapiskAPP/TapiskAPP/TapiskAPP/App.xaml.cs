using Prism;
using Prism.Ioc;
using TapiskAPP.ViewModels;
using TapiskAPP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TapiskAPP
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(MasterPage)}/{nameof(NavigationPage)}/{nameof(Views.MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage,MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterPage,MasterPageViewModel>();
        }
    }
}
