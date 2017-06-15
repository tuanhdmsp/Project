using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Lsjwzh.Widget.MaterialLoadingProgressBar;

namespace SafetyFirst
{
    [Activity(Label = "LoginActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class LoginActivity : AppCompatActivity, View.IOnClickListener, IOnCompleteListener
    {
        RelativeLayout activity_main;
        private Button btnLogin;
        private EditText txtUser;
        public static FirebaseApp app;
        private FirebaseAuth auth;
        private EditText txtPass;                
        private TextView textViewForgot;
        private TextView textViewCreate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.LoginLayout);

            //Init Firebase
            InitFirebaseAuth();

            //View
            txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            txtPass = FindViewById<EditText>(Resource.Id.txtPass);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            textViewCreate = FindViewById<TextView>(Resource.Id.btnSign);
            textViewForgot = FindViewById<TextView>(Resource.Id.btnForgot);
            activity_main = FindViewById<RelativeLayout>(Resource.Id.activity_main);

            txtPass.InputType = Android.Text.InputTypes.TextVariationPassword | Android.Text.InputTypes.ClassText;

            //Event click
            btnLogin.SetOnClickListener(this);
            textViewCreate.SetOnClickListener(this);
            textViewForgot.SetOnClickListener(this);
        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:764541794263:android:b68790d3348a4557")
                .SetApiKey("AIzaSyDJau-tqRro8J9UFeki3vKSJDaQ2iyY1NY")
                .Build();

            if (app == null)
            {
                app = FirebaseApp.InitializeApp(this, options);
            }
            auth = FirebaseAuth.GetInstance(app);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btnLogin)
            {
                LoginAccount(txtPass.Text, txtUser.Text);
            } else if (v.Id == Resource.Id.btnForgot)
            {
                StartActivity(new Intent(this, typeof(ForgotPassActiviy)));
                Finish();
            } else if (v.Id == Resource.Id.btnSign)
            {
                StartActivity(new Intent(this, typeof(SignUpActivity)));
                Finish();
            }
        }

        private void LoginAccount(string txtPassText, string txtUserText)
        {
            if (txtPassText == null || txtUserText == null || txtPassText == string.Empty || txtUserText == string.Empty)
            {
                Snackbar snackBar = Snackbar.Make(activity_main,  "Email or password is empty", Snackbar.LengthShort);
                snackBar.Show();
            }
            else
            {
                auth.SignInWithEmailAndPassword(txtUserText, txtPassText)
                    .AddOnCompleteListener(this);
            }           
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                StartActivity(new Intent(this, typeof(DashboardActivity)));
                Finish();
            }
            else
            {
                Snackbar snackBar = Snackbar.Make(activity_main, "Wrong email or password", Snackbar.LengthShort);
                snackBar.Show();
            }
        }
    }
} 