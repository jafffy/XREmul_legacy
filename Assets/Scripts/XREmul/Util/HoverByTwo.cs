using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;
public class HoverByTwo : MonoBehaviour {

    private InteractionBehaviour _intObj;
    private Material _material;

    // Use this for initialization
    void Start () {
        _intObj = GetComponent<InteractionBehaviour>();

        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            renderer = GetComponentInChildren<Renderer>();
        }
        if (renderer != null)
        {
            _material = renderer.material;
        }

        _intObj.OnHoverStay += Shining;
    }
	
    void Shining()
    {
        if(_intObj.hoveringControllers.Count == 2)
        {
            _material.color = new Color(Random.Range(0f, 1f),
                Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        _material.color = Color.Lerp(_material.color, Color.black, Time.deltaTime);
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        _intObj.OnHoverStay -= Shining;
    }

}
