using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LoginSystem
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }

    class dialog_SignUp : DialogFragment
    {
        private EditText mTxtFirstName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnSignUp;
        private Button Btnsignin;
        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;
        public event EventHandler<OnSigninEventArgs> mOnSigninComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
           
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);
            Btnsignin=view.FindViewById<Button>(Resource.Id.Btnsignin);
            mBtnSignUp.Click += mBtnSignUp_Click;
            Btnsignin.Click += Btnsignin_Click1;
            return view;
        }

       void Btnsignin_Click1(object sender, EventArgs e)
        {
            mOnSigninComplete.Invoke(this, new OnSigninEventArgs(Btnsignin.Text));
        }

        void mBtnSignUp_Click(object sender, EventArgs e)
        {
           //User has clicked the sign up button
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFirstName.Text, mTxtEmail.Text, mTxtPassword.Text));
            this.Dismiss();
        }
    
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
        }
    }

    public class OnSigninEventArgs : EventArgs
    {
        private string text;

        public OnSigninEventArgs(string text)
        {
            this.text = text;
        }
    }
}