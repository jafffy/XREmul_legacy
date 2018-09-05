using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GamePadHeadDirectionEmitter : AbstractHeadDirectionEmitter {
    public override Quaternion HeadDirection
    {
        get
        {
            var xboxOneController = GetComponent<XBoxOneController>();
            return xboxOneController.transform.localRotation;
        }
    }
}
