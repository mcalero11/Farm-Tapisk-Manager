using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;
using TapiskAPP.Droid.Services;
using TapiskAPP.Services;

namespace TapiskAPP.Droid
{
    [Activity(Label = "TapiskAPP", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
            
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        static StatusBarColorManager statusBarColorManager = new StatusBarColorManager();
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterInstance<IStatusBarColorManager>(statusBarColorManager);
        }
    }
}

