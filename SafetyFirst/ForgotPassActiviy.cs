using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase.Auth;

namespace SafetyFirst
{
    [Activity(Label = "ForgotPassActiviy", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class ForgotPassActiviy : AppCompatActivity, View.IOnClickListener, IOnCompleteListener
    {
        private EditText txtForgotEmail;
        private Button btnReset;
        private RelativeLayout forgot_layout;
        private TextView btnGoBack;
        private FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgetPassLayout);

            //InitFirebase

            auth = FirebaseAuth.GetInstance(LoginActivity.app);

            txtForgotEmail = FindViewById<EditText>(Resource.Id.forgot_email);
            btnReset = FindViewById<Button>(Resource.Id.forgot_btn_reset);
            btnGoBack = FindViewById<TextView>(Resource.Id.btnGoBack);
            forgot_layout = FindViewById<RelativeLayout>(Resource.Id.forgot_layout);

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
            if (string.IsNullOrEmpty(txtForgotEmail))
            {
                Snackbar snackBar = Snackbar.Make(forgot_layout, "Email is empty", Snackbar.LengthShort);
                snackBar.Show();
            }
            else
            {
                auth.SendPasswordResetEmail(txtForgotEmail).AddOnCompleteListener(this, this);
            }             
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful == true)
            {
                Snackbar snackBar = Snackbar.Make(forgot_layout, "Reset password link sent to email " + txtForgotEmail.Text, Snackbar.LengthShort);
                snackBar.Show();
            }
            else
            {
                Snackbar snackBar = Snackbar.Make(forgot_layout, "Reset password failed", Snackbar.LengthShort);
                snackBar.Show();
            }
        }
    }
}