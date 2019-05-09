//package com.exemple.repeatcall;

using Android.Annotation;//.SuppressLint;
using Android.Content;//.Intent;
using Android.Content.PM;
using Android.Net;//.Uri;
using Android.OS;//.Bundle;
using Android.Support.Annotation;//.NonNull;
using Android.Support.V4.App;//.ActivityCompat;
using Android.Support.V7.App;//.AppCompatActivity;
using Android.Telecom;//.TelecomManager;
using Android.Widget;//.EditText;
//using Java.Lang;
//using Java.Security;
using Java.Util;//.ArrayList;
using System;
using Uri = Android.Net.Uri;

using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;

using System.Reactive.Subjects;
using Java.Lang;
using System.Collections.Generic;
using System.Linq;




using static Android.Manifest.Permission;//.CALL_PHONE;
using static Android.Content.PM.PackageManager;//.PERMISSION_GRANTED;
//import static android.telecom.TelecomManager.ACTION_CHANGE_DEFAULT_DIALER;
//import static android.telecom.TelecomManager.EXTRA_CHANGE_DEFAULT_DIALER_PACKAGE_NAME;



namespace AndroidPhoneX
{
    public class DialerActivity : AppCompatActivity
    {
        EditText phoneNumberInput;
        private static int REQUEST_PERMISSION = 0;
        private static int REQUEST_CALL_PHONE = 0;

        //Permission = Android.Content.PM.Permission
        //@Override
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_dialer);

            phoneNumberInput = FindViewById<EditText>(Resource.Id.phoneNumberInput);

            //get Intent data (tel number)
            //if (getIntent().getData() != null)
            //    phoneNumberInput.setText(getIntent().getData().getSchemeSpecificPart());


            if (Intent.Data != null)//getIntent().getData()->Intent.Data
                phoneNumberInput.SetText((int)phoneNumberInput);
        }

        //@Override
        protected override void OnStart()
        {
            base.OnStart();
            //OfferReplacingDefaultDialer();

            //phoneNumberInput.SetOnEditorActionListener += (send, e) =>
            phoneNumberInput.Click += (sender, e) =>
            {
                makeCall();
                //return true;

            };
        }


        //@SuppressLint("MissingPermission")
        private void makeCall()
        {
            // If permission to call is granted
            if (CheckSelfPermission(Android.Manifest.Permission.CallPhone) == Permission.Granted)
            {
                // Create the Uri from phoneNumberInput
                Uri uri = Uri.Parse("tel:" + phoneNumberInput.ToString());
                // Start call to the number in input
                StartActivity(new Intent(Intent.ActionCall, uri));
            }
            else
            {
                // Request permission to call
                ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.CallPhone }, REQUEST_PERMISSION);
            }
        }
        //int requestCode, string[] permissions, Permission[] grantResult
        //@Override                                            int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            List<int> grantRes = new List<int>();
            // Add every result to the array
            for (int grantResult = 0; grantResults[grantResult] != 0; ++grantResult) grantRes.Add(grantResult);

            if (requestCode == REQUEST_PERMISSION && grantRes.Contains((int)Permission.Granted))
            {
                makeCall();
            }
        }


        /*
        public void OnRequestPermissionsResult1(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == REQUEST_CALL_PHONE)
            {
                if (grantResults.Length > 0 && grantResults[0] == PackageManager.Permission.Granted)
                {
                    makeCall();
                }
                else
                {
                    Toast.MakeText(this, "calling permission denied", ToastLength.Long).Show();
                }
                //return;
            }
        }
        */













        /*
        private void OfferReplacingDefaultDialer()
        {
            if (GetSystemService(TelecomManager.class).getDefaultDialerPackage() != getPackageName()){
                Intent ChangeDialer = new Intent(TelecomManager.ACTION_CHANGE_DEFAULT_DIALER);
                ChangeDialer.putExtra(TelecomManager.EXTRA_CHANGE_DEFAULT_DIALER_PACKAGE_NAME, getPackageName());
                startActivity(ChangeDialer);
            }
        }




    private void OfferReplacingDefaultDialer()
        {
            TelecomManager systemService = GetSystemService(TelecomManager.class);

            if (systemService != null && !systemService.GetDefaultDialerPackage().equals(this.getPackageName()))
            {
                StartActivity((new Intent(ACTION_CHANGE_DEFAULT_DIALER)).putExtra(EXTRA_CHANGE_DEFAULT_DIALER_PACKAGE_NAME, this.getPackageName()));
            }
        }
       
    }*/
    }
}
