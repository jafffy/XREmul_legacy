using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

using System.IO;
using System.Text;
using System.Linq;
public class LeapMotionSkeletonReplayEmitter : AbstractLeapmotionEmitter {
	public string LogfilePath;
	
    public override FrameData frameData
    {
        get
        {
			//TODO : 적절한 Cursor위치의 logFrameData 반환
            throw new System.NotImplementedException();
        }
    }
	//TODO : HeadDirectionReplayerEmitter에 따르면 Player가 bool 있는게 맞지만, 
	//함수로 빼는게 나을것 같아서 여기서는 빼는 형식으로 구현해 보기
	
	private List<Frame> logFrameData;
	private int cursor = 0;

    // Use this for initialization
    void Start () {
		//TODO : logFrameData Deserialization 하기 frame
		
		// Encoding.UTF8.GetString(
		// 	UnityEngine.Windows.File.ReadAllBytes(
		// 	Path.Combine(Application.dataPath,
		// 	LogfilePath + ".log")))
		// 	.Split("\n".ToCharArray(), 1)
		// 	.Select(x =>
		// 	{

		// 	})
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
