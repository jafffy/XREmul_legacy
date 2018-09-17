using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

using Leap.Unity;
using Leap;
using Leap.Unity.Encoding;

public class TestScript : MonoBehaviour {

    public LeapXRServiceProvider provider;

    public CapsuleHand rightHand;

    Frame capturedFrame;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CaptureFrame()
    {
        capturedFrame = provider.CurrentFrame;
        Debug.Log("frame " + capturedFrame.Id);
    }

    public void TransformFrame()
    {
        Hand source = HandUtils.Get(capturedFrame, Chirality.Right);

        rightHand.SetLeapHand(source);
        //VectorHand vHand = new VectorHand(source);
        //vHand.Decode(HandUtils.Get(provider.CurrentFrame, Chirality.Right));

        EditorApplication.isPaused = true;
    }
}
