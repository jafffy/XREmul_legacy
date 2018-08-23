using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TracerCore))]
public class TracerCoreEditor : Editor {
    enum PlayerState { Idle, Playing, Paused };
    enum RecorderState { Idle, Recording, Paused }

    PlayerState playerState = PlayerState.Idle;
    RecorderState recorderState = RecorderState.Idle;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var tracerCore = (TracerCore)target;

        GUILayout.Label(string.Format("Player State: {0}", playerState.ToString()));

        if (playerState == PlayerState.Idle)
        {
            if (GUILayout.Button("Play"))
            {
                playerState = PlayerState.Playing;
            }
        }
        else if (playerState == PlayerState.Playing)
        {
            if (GUILayout.Button("Pause"))
            {
                playerState = PlayerState.Paused;
            }

            if (GUILayout.Button("Stop"))
            {
                playerState = PlayerState.Idle;
            }
        }
        else if (playerState == PlayerState.Paused)
        {
            if (GUILayout.Button("Resume"))
            {
                playerState = PlayerState.Playing;
            }

            if (GUILayout.Button("Stop"))
            {
                playerState = PlayerState.Idle;
            }
        }

        GUILayout.Label(string.Format("Recorder State: {0}", recorderState.ToString()));

        if (recorderState == RecorderState.Idle)
        {
            if (GUILayout.Button("Record"))
            {
                recorderState = RecorderState.Recording;
            }
        }
        else if (recorderState == RecorderState.Recording)
        {
            if (GUILayout.Button("Pause"))
            {
                recorderState = RecorderState.Paused;
            }

            if (GUILayout.Button("Stop"))
            {
                recorderState = RecorderState.Idle;
            }
        }
        else if (recorderState == RecorderState.Paused)
        {
            if (GUILayout.Button("Resume"))
            {
                recorderState = RecorderState.Recording;
            }

            if (GUILayout.Button("Stop"))
            {
                recorderState = RecorderState.Idle;
            }
        }
    }
}
