using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHeadDirectionEmitter : MonoBehaviour {
    abstract public Quaternion HeadDirection { get; }
}
