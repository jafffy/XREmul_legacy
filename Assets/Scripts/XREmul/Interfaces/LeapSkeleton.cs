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
        //실제 스켈레톤을 Play시 움직이는 코드가 필요
        //하지만 원래 Interface의 목적은 Camera가 아닌 물체가 Camera를 움직이는 것 처럼
        //input 이 다른 device를 통해 전달될 떄 필요하다
        //말이 어려운데 아무튼 이 말의 의미는, 이 LeapSkeleton이 꼭 필요할까..? 이다..
        //마우스 같은게 Leap Skeleton을 움직일 수 있으면 모르겠는데
        //실질적으로 어려울 것 같다

    }
}
