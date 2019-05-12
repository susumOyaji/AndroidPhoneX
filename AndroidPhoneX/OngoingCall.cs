//package com.example.repeatcall;

using System;
using Android.Widget;
using Android.Telecom;//.Call;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using Java.Lang;
//using io.reactivex.subjects;
//using rx.Observer;
//using rx.subjects.BehaviorSubject;
using akarnokd.reactive_extensions;
//using Android.Graphics.Drawables; 
using System.Reactive.Concurrency;
using System.Reactive.Joins;
using Object = Java.Lang.Object;
//using static Android.Content.PM.LauncherApps;

namespace AndroidPhoneX
{
    public class OngoingCall
    {
        public BehaviorSubject<int> state;
        public Call.Callback callback;
        private Call call;


        public OngoingCall()
        {
            // Create a BehaviorSubject to subscribe
            state = new BehaviorSubject<int>(0);
            /*
            callback = new Call.Callback()
            {
                public void OnStateChanged(Call call, Integer newState)
                {
                    //Timber.d(call.toString());
                    // Change call state
                    this.state.OnNext(newState);
                }
            };*/
        }


        public BehaviorSubject<int> getState()
        {
            return state;
        }

        public void SetCall(Call value)
        {
            if (call != null)
            {
                call.UnregisterCallback(callback);
            }

            if (value != null)
            {
                value.RegisterCallback(callback);
                //state.OnNext(value.getState());
            }

            call = value;
        }

        // Anwser the call
        public void answer()
        {
            call.Answer(0);
        }

        // Hangup the call
        public void hangup()
        {
            call.Disconnect();
        }

}//Class of end

}


   /*
    public enum {
        // Create a BehaviorSubject to subscribe
        state = BehaviorSubject<int>.create(),
        callback = new Call.Callback(){
            public void OnStateChanged(Call call, Integer newState){
                //Timber.d(call.toString());
                // Change call state
                OngoingCall.state.OnNext((int)newState);
            }
        };
    }
    */





    


