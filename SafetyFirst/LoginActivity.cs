using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SafetyFirst
{
    [Activity(Label = "LoginActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class LoginActivity : AppCompatActivity
    {
        private Button btnLogin;
        private EditText txtUser;
        private EditText txtPass;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Resource.Style.Theme_AppCompat_DayNight_NoActionBar);
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.LoginLayout);
            txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            txtPass = FindViewById<EditText>(Resource.Id.txtPass);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            txtPass.InputType = Android.Text.InputTypes.TextVariationPassword | Android.Text.InputTypes.ClassText;

            btnLogin.Click += BtnLoginOnClick;
        }


        private void BtnLoginOnClick(object sender, EventArgs eventArgs)
        {
            Toast.MakeText(this, string.Format("User:{0}  Password:{1}", txtUser.Text, txtPass.Text), ToastLength.Short).Show();
        }
    }
}