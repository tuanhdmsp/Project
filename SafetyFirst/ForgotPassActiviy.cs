using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SafetyFirst
{
    [Activity(Label = "ForgotPassActiviy", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class ForgotPassActiviy : AppCompatActivity, View.IOnClickListener
    {
        private EditText txtForgotEmail;
        private Button btnReset;
        private TextView btnGoBack;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgetPassLayout);
            txtForgotEmail = FindViewById<EditText>(Resource.Id.forgot_email);
            btnReset = FindViewById<Button>(Resource.Id.forgot_btn_reset);
            btnGoBack = FindViewById<TextView>(Resource.Id.btnGoBack);

            btnReset.SetOnClickListener(this);
            btnGoBack.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.forgot_btn_reset)
            {
                ResetPassword(txtForgotEmail.Text);
            }
            else if (v.Id == Resource.Id.btnGoBack)
            {
                StartActivity(new Intent(this, typeof(LoginActivity)));
                Finish();
            }
        }

        public override void OnBackPressed()
        {
            StartActivity(new Intent(this, typeof(LoginActivity)));
            Finish();
        }

        private void ResetPassword(string txtForgotEmail)
        {
            Toast.MakeText(this, string.Format("Email:{0}", txtForgotEmail), ToastLength.Short).Show();
        }
    }
}