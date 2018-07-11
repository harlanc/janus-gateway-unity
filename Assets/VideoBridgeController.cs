using UnityEngine;
using System.Collections;
using Application;
using UnityEngine.UI;
using System.Collections.Generic;

public class VideoBridgeController : MonoBehaviour
{

    public static bool micOpen = false;
    public static bool speakerOpen = false;

    Janus voicecontroller = new Janus();
    // Use this for initialization
    void Start()
    {
        voicecontroller.setContext();
        voicecontroller.init();
    

        //voicecontroller.openMic();
        //voicecontroller.openSpeaker();

        List<string> btnsName = new List<string>();
        btnsName.Add("BtnOpenMic");
        btnsName.Add("BtnOpenSpeaker");
   
 
        foreach(string btnName in btnsName)
        {
            GameObject btnObj = GameObject.Find(btnName);
            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(delegate() {
                this.OnClick(btnObj); 
            });
        } 

    }

    public void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            case "BtnOpenMic":
                Debug.Log("BtnOpenMic");
                if (micOpen)
                {
                    voicecontroller.closeMic();
                }
                else
                {
                    voicecontroller.openMic();
                }
                micOpen = !micOpen;
                break;
            case "BtnOpenSpeaker":
                Debug.Log("BtnOpenSpeaker");
                if (speakerOpen)
                {
                    voicecontroller.closeSpeaker();
                }
                else
                {
                    voicecontroller.openSpeaker();
                }
                speakerOpen = !speakerOpen;
                break;
              default:
                Debug.Log("none");
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
