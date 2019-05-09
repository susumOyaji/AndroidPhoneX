//package com.example.repeatcall;

using Android.Telecom;//.Call;
//using Android.Telecom;//.InCallService;
using Android.Widget;//.Toast;


namespace AndroidPhoneX
{ 

    public class CallService : InCallService
    {
    //@Override
    public override void OnCallAdded(Call call) {
        new OngoingCall().SetCall(call);
        Toast.MakeText(this, "class to CallService", ToastLength.Short).Show();
        CallActivity.Start(this, call);
    }

    //@Override
    public override void OnCallRemoved(Call call) {
        new OngoingCall().SetCall(null);
    }   
    }
}