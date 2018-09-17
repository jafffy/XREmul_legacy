using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Leap;
using Leap.Unity;

public class LeapMotionController : MonoBehaviour
{
    public CapsuleHand leftHand;
    public CapsuleHand rightHand;

    void Awake()
    {
        if (leftHand.Handedness != Chirality.Left)
        {
            Debug.LogError("Wrong Hand Matching");
        }
    }


    public List<Vector3>[] GetHandPositions(CapsuleHand target)
    {
        Hand hand = target.GetLeapHand();
        if(hand == null)
        {
            return null;
        }

        int arrayLength = hand.Fingers.Count + 1;
        List<Vector3>[] indexedArray = new List<Vector3>[arrayLength];
        int i = 0;
        //Fingers
        foreach (var finger in hand.Fingers)
        {
            List<Vector3> positions = new List<Vector3>();
            for (int j = 0; j < 4; j++)
            {
                int key = getFingerJointIndex((int)finger.Type, j);
                Vector3 position = finger.Bone((Bone.BoneType)j).NextJoint.ToVector3();
                positions.Add(position);
            }
            indexedArray[i++] = positions;
        }
        //Palm
        List<Vector3> palmPositions = new List<Vector3>();
        Vector3 palmPosition = hand.PalmPosition.ToVector3();
        palmPositions.Add(palmPosition);
        indexedArray[i] = palmPositions;
        return indexedArray;
    }

    private int getFingerJointIndex(int fingerIndex, int jointIndex)
    {
        return fingerIndex * 4 + jointIndex;
    }

    public void ForDebugTracerGlobalWrapper()
    {
        TracerGlobal.Instance.DumpToFile();
    }
}
