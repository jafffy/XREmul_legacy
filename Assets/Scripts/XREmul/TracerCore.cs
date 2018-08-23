using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerCore : MonoBehaviour {
    public List<GameObject> TrackingObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}

    private int index = 0;
	
	// Update is called once per frame
	void Update () {
        if (CurrentPlayerState == PlayerState.Playing)
        {
            foreach (var gameObject in TrackingObjects)
            {
                gameObject.transform.eulerAngles =
                    XRHMDTracer.Singleton.traces[index].Direction;
                gameObject.transform.position =
                    XRHMDTracer.Singleton.traces[index].Position;
            }

            PlayerTimer += Time.deltaTime;
            index = index + 1;
        }
        if (CurrentRecorderState == RecorderState.Recording)
        {
            foreach (var gameObject in TrackingObjects)
            {
                XRHMDTracer.Singleton.Insert(
                    RecorderTimer,
                    gameObject.transform.eulerAngles,
                    gameObject.transform.position);
            }

            RecorderTimer += Time.deltaTime;
        }
    }

    public void StartPlay()
    {
        PlayerTimer = 0.0f;
    }

    public void StopPlay()
    {

    }

    public void StartRecord()
    {
        RecorderTimer = 0.0f;

        XRHMDTracer.Singleton.Clear();
    }

    public void StopRecord()
    {
    }

    public PlayerState CurrentPlayerState = PlayerState.Idle;
    public RecorderState CurrentRecorderState = RecorderState.Idle;
    public float RecorderTimer = 0.0f;
    public float PlayerTimer = 0.0f;
}

public enum PlayerState { Idle, Playing, Paused };
public enum RecorderState { Idle, Recording, Paused }
