using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;
using Leap.Unity;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

//using Newtonsoft.Json;

public abstract class AbstractLeapmotionEmitter : AbstractRecorder {

	public struct FrameData
    {
		public Frame frame;
    }


    abstract public FrameData frameData { get; }

    internal override string GetRecordEntry()
    {
        FrameData data = frameData;

        //JsonSerializerSettings settings = new JsonSerializerSettings();
        //settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

		return "";//JsonConvert.SerializeObject(data, settings);
    }
}

