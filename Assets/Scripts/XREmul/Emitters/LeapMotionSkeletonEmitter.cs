using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;
using Leap.Unity;

public class LeapMotionSkeletonEmitter : AbstractLeapmotionEmitter
{
    //API에 의한 Dependency가 생겨도 괜찮다 (이 클래스에서)
    [HideInInspector]
    public LeapXRServiceProvider provider;

    void Start()
    {
        if(provider == null)
        {
            provider = GetComponent<LeapXRServiceProvider>();
            if(provider == null)
                Debug.LogError("No Valid LeapXRServiceProvider");
        }
    }
    public override FrameData frameData
    {
        get
        {
            return new FrameData()
            {
                frame = new Frame().CopyFrom(provider.CurrentFrame) // Make hard-copy
            };
        }
    }

    
}
