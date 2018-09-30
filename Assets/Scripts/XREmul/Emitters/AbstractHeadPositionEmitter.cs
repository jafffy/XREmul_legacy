using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHeadPositionEmitter : AbstractRecorder {
    abstract public Vector3 HeadPosition { get; }

    internal override object GetRecordEntry()
    {
        Vector3 pos = HeadPosition;

        return string.Format("{0},{1},{2}", pos.x, pos.y, pos.z);
    }
}
