//package com.example.repeatcall;
using System;
using Android.Annotation;//.SuppressLint;
using Java.Lang;

//import timber.log.Timber;


namespace AndroidPhoneX
{

    class CallStateString {
        //@SuppressLint("TimberArgCount")
        public string AsString(int receiver) {
            string state;

            switch (receiver) {
            case 0:
                state = "NEW";
                break;
            case 1:
                state = "DIALING";
                break;
            case 2:
                state = "RINGING";
                break;
            case 3:
                state = "HOLDING";
                break;
            case 4:
                state = "ACTIVE";
                break;
            case 5:
            case 6:
            default:
                //Timber.w("Unknown state %s", $receiver, new Object[0]);
                state = "UNKNOWN";
                break;
            case 7:
                state = "DISCONNECTED";
                break;
            case 8:
                state = "SELECT_PHONE_ACCOUNT";
                break;
            case 9:
                state = "CONNECTING";
                break;
            case 10:
                state = "DISCONNECTING";
                break;
            }

            return state;
        }
    }
}
