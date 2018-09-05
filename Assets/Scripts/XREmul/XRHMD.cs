using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRHMD {
    public Vector3 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public Vector3 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    private Vector3 _direction;
    private Vector3 _position;
}
