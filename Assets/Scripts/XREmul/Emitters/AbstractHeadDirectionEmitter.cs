using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHeadDirectionEmitter : AbstractRecorder {
    abstract public Quaternion HeadDirection { get; }

    internal override object GetRecordEntry()
    {
        Vector3 euler = HeadDirection.eulerAngles;

        return string.Format("{0},{1},{2}", euler.x, euler.y, euler.z);
    }
}
