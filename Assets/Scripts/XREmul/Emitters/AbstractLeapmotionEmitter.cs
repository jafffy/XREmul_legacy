using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;
using Leap.Unity;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
public abstract class AbstractLeapmotionEmitter : AbstractRecorder {

	public struct FrameData
    {
		public Frame frame;
    }

    abstract public FrameData frameData { get; }

    internal override string GetRecordEntry()
    {
        FrameData data = frameData;
		return SerializableToCSV.Serialize(data.frame);
    }
}

