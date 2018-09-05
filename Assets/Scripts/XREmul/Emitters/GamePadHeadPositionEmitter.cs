using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GamePadHeadPositionEmitter : AbstractHeadPositionEmitter {
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state, prevState;
    
    public override Vector3 HeadPosition
    {
        get
        {
            var xboxOneController = GetComponent<XBoxOneController>();
            return xboxOneController.transform.localPosition;
        }
    }
}
