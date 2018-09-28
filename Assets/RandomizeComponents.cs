using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;
public class RandomizeComponents : MonoBehaviour {

	public GameObject source;
	public GameObject target;

	private Vector3 originPos;

	// Use this for initialization
	void Start () {
		if(target!=null)
		{
			originPos = target.transform.position;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RandomizeSetting()
	{
		Component comp =target.gameObject.GetComponent<SimpleInteractionGlow>();
		Component comp2 = target.gameObject.GetComponent<HoverByTwo>();

		if(comp != null)
		{
			DestroyImmediate(comp);
		}
		if(comp2 != null)
		{
			DestroyImmediate(comp2);
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

	public void RandomizeSetting2()
	{
		Component comp =target.gameObject.GetComponent<InteractionBehaviour>();
		//Component comp2 = target.gameObject.GetComponent<HoverByTwo>();

		if(comp != null)
		{
			DestroyImmediate(comp);
		}
		// if(comp2 != null)
		// {
		// 	DestroyImmediate(comp2);
		// }

		if(Random.Range(0,2) == 0)
		{
			ComponentCopyUtility.CopyComponentAsNew<InteractionBehaviour>(source, target);
		}
		// if(Random.Range(0,2) == 0)
		// {
		// 	ComponentCopyUtility.CopyComponentAsNew<HoverByTwo>(source,target);
		// }
		target.transform.position =originPos;
		
	}
}
