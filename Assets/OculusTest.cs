using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusTest : MonoBehaviour {

    MeshRenderer m_render;
    float bucket;

    public Color origin = Color.white;
    public Color dest = Color.cyan;

    void Update()
    {
        bucket -= Time.deltaTime;
        if(bucket < 0)
        {
            bucket = 0;
        }

        m_render.material.color = Color.Lerp(origin, dest, bucket / 6.0f);
    }

    void Start()
    {
        m_render = GetComponent<MeshRenderer>();
    }

    public void OnGazing()
    {
        bucket += Time.deltaTime * 5;

        if(bucket > 6.0f)
        {
            Destroy(gameObject);
        }
    }
}
