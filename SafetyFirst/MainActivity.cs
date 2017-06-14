using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using GR.Net.Maroulis.Library;

namespace SafetyFirst
{
    [Activity(Label = "SafetyFirst", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var config = new EasySplashScreen(this)
                .WithFullScreen()
                .WithTargetActivity(Java.Lang.Class.FromType(typeof(LoginActivity)))
                .WithSplashTimeOut(4000)
                .WithBackgroundResource(Resource.Drawable.splashscreen);
            View view = config.Create();
            SetContentView(view);
        }
    }
}

