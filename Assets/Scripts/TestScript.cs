using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

using Leap.Unity;
using Leap;
using Leap.Unity.Encoding;
using Leap.Unity.Interaction;
public class TestScript : MonoBehaviour {
    public HandModelManager handModelManager;
    public LeapXRServiceProvider provider;
    public InteractionHand rightHand;
    public InteractionHand leftHand;

    Frame[] capturedFrames;
    int cursor = 0;
    bool captureEnable = false;


    // Use this for initialization
    void Start () {
        capturedFrames = new Frame[300];
	}
	

    void FixedUpdate()
    {
        if(captureEnable)
        {
            Frame hardCopy = new Frame();
            hardCopy.CopyFrom(provider.CurrentFrame);
            capturedFrames[cursor++] = hardCopy;
            
        }
        if(cursor == capturedFrames.Length && captureEnable)
        {
            Debug.Log("Completed");
            captureEnable = false;
            LeapDataProvider.getInstance().savedFrame = capturedFrames;
        }
    }

    public void CaptureFrameFor3Seconds()
    {
        captureEnable = true;
    }
    
    public void ChangeProvider()
    {
        Debug.Log("Changed");
        handModelManager.leapProvider = LeapDataProvider.getInstance();
        provider.enabled = false;
         leftHand.leapProvider = LeapDataProvider.getInstance();
        rightHand.leapProvider = LeapDataProvider.getInstance();

        LeapDataProvider.getInstance().StartReplay();
    }

}
