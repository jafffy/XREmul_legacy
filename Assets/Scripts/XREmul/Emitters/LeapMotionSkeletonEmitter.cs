using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;
using Leap.Unity;

public class LeapMotionSkeletonEmitter : AbstractLeapSkeletonEmitter
{
    LeapMotionController LeapController;

    void Start()
    {
        LeapController = GetComponent<LeapMotionController>();
    }

    public override SkeletonPair SkeletonData
    {
        get
        {
            return new SkeletonPair
            {
                LeftHandPositions = LeapController.GetHandPositions(LeapController.leftHand),
                RightHandPositions = LeapController.GetHandPositions(LeapController.rightHand)
            }; 
        }
    }

}
