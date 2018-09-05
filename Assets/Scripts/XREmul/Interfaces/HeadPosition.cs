using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPosition : MonoBehaviour {
	public GameObject HeadPositionEmitter;
	public Camera Camera;

	void Update () {
		var emitter = HeadPositionEmitter.GetComponent<AbstractHeadPositionEmitter>();

		Camera.transform.localPosition = emitter.HeadPosition;
	}
}
