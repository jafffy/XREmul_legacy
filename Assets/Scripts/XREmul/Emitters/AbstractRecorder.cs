using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRecorder : MonoBehaviour {
    public bool IsRecording = false;
    public string RecordingSourceName;

    private float timer_ = 0.0f;

    void Start()
    {
        timer_ = 0.0f;
    }
    
	void Update()
    {
        if (IsRecording && RecordingSourceName != null)
        {
            TracerGlobal.Instance.Record(RecordingSourceName, timer_, GetRecordEntry());
            timer_ += Time.deltaTime;
        }
	}

    internal abstract string GetRecordEntry();
}
