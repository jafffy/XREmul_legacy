using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLeapSkeletonEmitter : AbstractRecorder {
    public struct SkeletonPair
    {
        public List<Vector3>[] LeftHandPositions;
        public List<Vector3>[] RightHandPositions;
    }

    abstract public SkeletonPair SkeletonData { get; }

    internal override string GetRecordEntry()
    {
        //Record 시 필요한 데이터를 보낸다. 단 LeftHandPosition과 RightHandPositiong에서 알 수 있는 정보로 보내야함.
        SkeletonPair data = SkeletonData;
        string str = "";
        if(data.LeftHandPositions != null)
        {
            for (int i = 0; i < data.LeftHandPositions.Length; i++)
            {
                List<Vector3> row = data.LeftHandPositions[i];
                for (int j = 0; j < row.Count; j++)
                {
                    str += string.Format("{0},{1},{2},", row[j].x, row[j].y, row[j].z);
                }
            }
        }
        if(data.RightHandPositions != null)
        {
            for (int i = 0; i < data.RightHandPositions.Length; i++)
            {
                List<Vector3> row = data.RightHandPositions[i];
                for (int j = 0; j < row.Count; j++)
                {
                    str += string.Format(j == row.Count - 1 ? "{0},{1},{2}" : "{0},{1},{2},", row[j].x, row[j].y, row[j].z);
                }
            }
        }
        return str;
    }
}


