﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace LoginSystem
{
    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnSignUp;
        private Button Btnsignin;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            Btnsignin = FindViewById<Button>(Resource.Id.Btnsignin);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mBtnSignUp.Click += (object sender, EventArgs args) =>
                {
                    //Pull up dialog
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    dialog_SignUp signUpDialog = new dialog_SignUp();
                    signUpDialog.Show(transaction, "dialog fragment");

                    signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
                   
                };
            Btnsignin.Click += (object sender, EventArgs args) =>
            {
                dialog_SignUp signinlog = new Dialog_Signin();

            };
        }

        void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {

            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();
    

        }
       
        private void ActLikeARequest()
        {
           // Thread.Sleep(10);

            RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
            int x = Resource.Animation.left_move;
        }
    }
}

