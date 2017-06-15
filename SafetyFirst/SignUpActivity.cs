using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
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
    [Activity(Label = "SignUpActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class SignUpActivity : AppCompatActivity, View.IOnClickListener, IOnCompleteListener
    {
        private TextView textViewBack;
        private RelativeLayout activity_sign_up;
        private Button btnRegistration;
        private EditText txtUser;
        private EditText txtPass;

        private FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateLayout);

            //InitFirebase

            auth = FirebaseAuth.GetInstance(LoginActivity.app);

            textViewBack = FindViewById<TextView>(Resource.Id.btnBack);
            btnRegistration = FindViewById<Button>(Resource.Id.btnSignUp);
            txtUser = FindViewById<EditText>(Resource.Id.sign_up_email);
            txtPass = FindViewById<EditText>(Resource.Id.sign_up_pass);
            activity_sign_up = FindViewById<RelativeLayout>(Resource.Id.activity_sign_up);

            btnRegistration.SetOnClickListener(this);
            textViewBack.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btnSignUp)
            {
                CreateAccout(txtUser.Text, txtPass.Text);
            } else if (v.Id == Resource.Id.btnBack)
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

        private void CreateAccout(string txtUserText, string txtPassText)
        {
            if (txtPassText == null || txtUserText == null || txtPassText == string.Empty ||
                txtUserText == string.Empty)
            {
                Snackbar snackBar = Snackbar.Make(activity_sign_up, "Email or password is empty", Snackbar.LengthShort);
                snackBar.Show();
            }
            else
            {
                auth.CreateUserWithEmailAndPassword(txtUserText, txtPassText)
                    .AddOnCompleteListener(this, this);
            }               
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful == true)
            {
                Snackbar snackBar = Snackbar.Make(activity_sign_up, "Register successfully", Snackbar.LengthShort);
                snackBar.Show();
            }
            else
            {
                Snackbar snackBar = Snackbar.Make(activity_sign_up, "Register Failed", Snackbar.LengthShort);
                snackBar.Show();
            }
        }
    }
}