//package com.example.repeatcall;

using System;
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

using System.Reactive.Concurrency;
using System.Reactive.Joins;
using Object = Java.Lang.Object;
//using static Android.Content.PM.LauncherApps;

namespace AndroidPhoneX
{
    public class OngoingCall
    {
        public BehaviorSubject<int> state = BehaviorSubject<int>(0);
        private Call.Callback callback;
        private Call call;

       

        public BehaviorSubject<int> GetState()
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
            var oddNumbers = Observable.Range(0, 10)
            .Where(i => i % 2 == 0)
            .Subscribe(Console.WriteLine,() => Console.WriteLine("Completed"));

            //var create = ReactiveExtensions.Create();
            //state = BehaviorSubject<int>(0);


        }



        
        //Subject f = Subject.Create<>;// .Finalize();

        
         //static enum {
            // Create a BehaviorSubject to subscribe
        
            //state = BehaviorSubject<int>(0);
            /*
            callback = new Call.Callback(){
                
                public void OnStateChanged(Call call, int newState)
                {
                    //Timber.d(call.toString());
                    //Change call state
                    state.OnNext(newState);
                }
            };*/
        //}
        
    }//Class of end

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


}






    


