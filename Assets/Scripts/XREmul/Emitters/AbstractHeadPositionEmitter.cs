using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHeadPositionEmitter : MonoBehaviour {
    abstract public Vector3 HeadPosition { get; }
}
