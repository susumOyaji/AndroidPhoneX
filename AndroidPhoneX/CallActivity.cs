//package com.example.repeatcall;

using System;
using System.Text;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;//.Context;
using Android.Telecom;//.Call;
using Android.Support.V4.App;//.ActivityCompat;
using Android.Support.V7.App;//.AppCompatActivity;
using System.Collections.Generic;
using System.Reactive;
//using System.Reactive.Core;
//using System.Reactive.Interfaces;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
//using Microsoft.Reactive.Testing;
using System.Reactive.Disposables;
using akarnokd.reactive_extensions;

using System.Linq;
using Java.Util;
using Android;
using AndroidPhoneX;

//using io.reactive.Disposables.CompositeDisposable;
//using io.reactivex.disposables.Disposable;






namespace AndroidPhoneX
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    //[Activity(Label = "Android Phone", MainLauncher = true, Icon = "@drawable/icon")]
    public class CallActivity : Activity
    {
        CallStateString callStateString = new CallStateString();
        OngoingCall ongoingCall = new OngoingCall();


        private CompositeDisposable disposables = new CompositeDisposable();
        private string number;
        private Button answer, hangup;
        private TextView callInfo,textView;
       


        //@Override
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_call);


            // Get our UI controls from the loaded layout
            callInfo = FindViewById<TextView>(Resource.Id.callInfo);
            textView = FindViewById<TextView>(Resource.Id.textView2);
            answer = FindViewById<Button>(Resource.Id.answer);
            hangup = FindViewById<Button>(Resource.Id.hangup);


            number = "Input to PhoneNumber";// getIntent().getData().getSchemeSpecificPart();
       }

        //@SuppressLint("CheckResult")
        //@Override
       
        protected override void OnStart()
        {
            base.OnStart();
            answer.Click += (sender, e) =>
                 {
                //answer.setOnClickListener(v -> OngoingCall.answer());
                ongoingCall.answer();
                 };

            hangup.Click += (sender, e) =>
            {
                //hangup.setOnClickListener(v -> OngoingCall.hangup());
                ongoingCall.hangup();
            };


            // Subscribe to state change -> call updateUi when change
            //new OngoingCall();

            IDisposable disposable = ongoingCall.state.Subscribe(this.UpdateUi);
            disposables.Add(disposable);

            // Subscribe to state change (only when disconnected) -> call finish to close phone call
            //new OngoingCall();
            IDisposable disposable2 = ongoingCall.state
                .Where(state => state == (int)CallState.Disconnected)
                .Delay(TimeSpan.FromSeconds(1))
                .FirstElement()
                .Subscribe(this.Finish);

            disposables.Add(disposable2);
        }

        // Call to Activity finish
        public void  Finish(int state)
        {
            Finish();
        }

       


        // Set the UI for the call
        //@SuppressLint("SetTextI18n")
        public void UpdateUi(int state)
        {
            //callInfotext("callInfo");

            //callInfo.SetText(answer, Resource.Id.callInfo);
            answer.SetText(Resource.Id.callInfo);
            // Set callInfo text by the state
            //callInfo.SetText(callStateString.AsString(state).ToLowerInvariant() + "\n" + "\n" + number);
            callInfo.Text = callStateString.AsString(state).ToLowerInvariant()  + "\n" + number;


            if (state == (int)CallState.Ringing)

                answer.Visibility = Android.Views.ViewStates.Invisible;//= ViewStates.Invisible(View.VISIBLE);
            else
                answer.Visibility = Android.Views.ViewStates.Visible; //setVisibility(View.GONE);

            if (state == (int)CallState.Dialing || state == (int)CallState.Ringing || state == (int)CallState.Active)
                hangup.Visibility = Android.Views.ViewStates.Invisible; //setVisibility(View.VISIBLE);
            else
                hangup.Visibility = Android.Views.ViewStates.Invisible; //setVisibility(View.GONE);
        }



        //@Override
        protected override void OnStop()
        {
            base.OnStop();
            disposables.Clear();
        }


        public static void Start(Context context, Call call)
        {
            context.StartActivity(new Intent(context, typeof(CallActivity))
                    .SetFlags(ActivityFlags.NewTask/*FLAG_ACTIVITY_NEW_TASK*/)
                    .SetData(call.GetDetails().GetHandle()));
        }
    }

}
