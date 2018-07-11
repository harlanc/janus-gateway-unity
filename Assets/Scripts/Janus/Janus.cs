using System;
using System.Collections.Generic;
using UnityEngine;
namespace Application
{
    public class Janus
    {
        private static  AndroidJavaObject jObj_janusclientAPI = null; 
        private static AndroidJavaObject jObj_curcontext = null; 

        private static AndroidJavaObject GetJavaObject_janusclientAPI()
        {
            if (jObj_janusclientAPI == null)
            {
                jObj_janusclientAPI = new AndroidJavaObject("computician.janusclientapi.JanusAudioBridge");
            }
            return jObj_janusclientAPI;
        }


        public static AndroidJavaObject GetContext(){

            if(jObj_curcontext == null){
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                jObj_curcontext = activity.Call<AndroidJavaObject>("getApplicationContext");
                
            }
            return jObj_curcontext;
        }

        public   void setContext()
        {
            GetJavaObject_janusclientAPI().Call("SetContext", GetContext());
            
        }
        public  void init()
        {
            GetJavaObject_janusclientAPI().Call("init");
        }

        public  void openMic()
        {
            GetJavaObject_janusclientAPI().Call("openMic");
            
        }
        public void closeMic()
        {
            GetJavaObject_janusclientAPI().Call("closeMic");

        }

        public void closeSpeaker()
        {
            GetJavaObject_janusclientAPI().Call("closeSpeaker");

        }

        public void openSpeaker()
        {
            GetJavaObject_janusclientAPI().Call("openSpeaker");
        }



    }
}
