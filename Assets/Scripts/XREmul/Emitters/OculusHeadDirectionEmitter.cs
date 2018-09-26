using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusHeadDirectionEmitter : AbstractHeadDirectionEmitter {

    OVRCameraRig instance;

    public override Quaternion HeadDirection
    {
        get
        {
            return instance.gameObject.transform.rotation;
        }
    }

    void Start()
    {
        instance = FindObjectOfType<OVRCameraRig>();
    }

    void Update()
    {
        Debug.DrawLine(instance.gameObject.transform.position,
            instance.gameObject.transform.rotation * Vector3.forward * 5.0f
            ,Color.red
            );
        RaycastHit hit;
        if(Physics.Raycast(instance.gameObject.transform.position , instance.gameObject.transform.rotation * Vector3.forward , out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            OculusTest s = hit.collider.gameObject.GetComponent<OculusTest>();
            if(s!=null)
            {
                s.OnGazing();
            }
        }
    }

}
