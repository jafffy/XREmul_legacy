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
using Leap.Unity.Encoding;

public abstract class AbstractLeapmotionEmitter : AbstractRecorder {

	public struct FrameData
    {
		public Frame frame;

        public override string ToString()
        {
            VectorHand vectorHand = new VectorHand();
            List<byte[]> byteSet = new List<byte[]>();
            byte[] bytes;
            int offset = 0;
            foreach(var hand in frame.Hands)
            {
                bytes = new byte[vectorHand.numBytesRequired];
                vectorHand.FillBytes(bytes, ref offset, hand);

                offset = 0;
                byteSet.Add(bytes);
            }
            //long id, long timestamp, float fps & hands
            string str = string.Format("{0},{1},{2}",frame.Id, frame.Timestamp, frame.CurrentFramesPerSecond);
            foreach(var byt in byteSet)
            {
                str += "," + Encoding.UTF8.GetString(byt);
            }
            return str;
        }
    }


    abstract public FrameData frameData { get; }

    internal override object GetRecordEntry()
    {
        return frameData;
    }
}

