using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;
public class RandomizeComponents : MonoBehaviour {

	public GameObject source;
	public GameObject target;

	private Vector3 originPos;
	private Quaternion originRot;

	// Use this for initialization
	void Start () {
		if(target!=null)
		{
			originPos = target.transform.position;
			originRot = target.transform.rotation;
		}
	}


	public void RandomizeHoverSetting()
	{
		Component singleHover =target.gameObject.GetComponent<SimpleInteractionGlow>();
		Component doubleHover = target.gameObject.GetComponent<HoverByTwo>();

		if(singleHover != null)
		{
			DestroyImmediate(singleHover);
		}
		if(doubleHover != null)
		{
			DestroyImmediate(doubleHover);
		}

		if(Random.Range(0,2) == 0)
		{
			ComponentCopyUtility.CopyComponentAsNew<SimpleInteractionGlow>(source, target);
		}
		if(Random.Range(0,2) == 0)
		{
			ComponentCopyUtility.CopyComponentAsNew<HoverByTwo>(source,target);
		}

		
	}

	public void RandomizeGraspSetting()
	{
		Component grasp =target.gameObject.GetComponent<InteractionBehaviour>();

		if(grasp != null)
		{
			DestroyImmediate(grasp);
		}

		if(Random.Range(0,2) == 0)
		{
			ComponentCopyUtility.CopyComponentAsNew<InteractionBehaviour>(source, target);
		}
		target.transform.position = originPos;
		target.transform.rotation = originRot;
	}
}
