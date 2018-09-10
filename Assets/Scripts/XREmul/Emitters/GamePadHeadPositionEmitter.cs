using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GamePadHeadPositionEmitter : AbstractHeadPositionEmitter {    
    public override Vector3 HeadPosition
    {
        get
        {
            var xboxOneController = GetComponent<XBoxOneController>();
            return xboxOneController.transform.localPosition;
        }
    }
}
