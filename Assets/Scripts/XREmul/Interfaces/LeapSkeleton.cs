using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapSkeleton : MonoBehaviour {
    public GameObject LeapSkeletonEmitter;
    LeapMotionSkeletonEmitter ScriptEmitter;

    void Start()
    {
        ScriptEmitter = LeapSkeletonEmitter.GetComponent<LeapMotionSkeletonEmitter>();
    }
    void Update()
    {
        //? : 이 코드가 필요할까? 어짜피 Leap Model들은 Leap에 의해 제어
        //+ 다른 Input을 통해 Leap을 제어하기는 어려워 보인다 
    }
}
