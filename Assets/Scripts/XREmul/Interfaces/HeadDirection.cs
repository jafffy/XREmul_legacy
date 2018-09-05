using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDirection : MonoBehaviour {
    public GameObject HeadDirectionEmitter;
    public Camera Camera;

	void Update () {
        var emitter = HeadDirectionEmitter.GetComponent<AbstractHeadDirectionEmitter>();

        Camera.transform.localRotation = emitter.HeadDirection;
	}
}
