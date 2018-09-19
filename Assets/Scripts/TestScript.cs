using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

using Leap.Unity;
using Leap;
using Leap.Unity.Encoding;

public class TestScript : MonoBehaviour {
    public HandModelManager handModelManager;
    public LeapXRServiceProvider provider;
    public CapsuleHand rightHand;
    Frame[] capturedFrames;
    int cursor = 0;
    bool captureEnable = false;


    // Use this for initialization
    void Start () {
        capturedFrames = new Frame[150];
	}
	
	// Update is called once per frame
	void Update () {
		
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
        LeapDataProvider.getInstance().StartReplay();
    }

}
