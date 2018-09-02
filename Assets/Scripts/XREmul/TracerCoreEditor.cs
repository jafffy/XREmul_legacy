using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using PlayerState = TracerCore.PlayerState;
using RecorderState = TracerCore.RecorderState;

[CustomEditor(typeof(TracerCore))]
public class TracerCoreEditor : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var tracerCore = (TracerCore)target;

        GUILayout.Label(string.Format("Player State: {0}", tracerCore.CurrentPlayerState.ToString()));

        if (tracerCore.CurrentPlayerState == PlayerState.Idle)
        {
            if (GUILayout.Button("Play"))
            {
                tracerCore.StartPlay();

                tracerCore.CurrentPlayerState = PlayerState.Playing;
            }
        }
        else if (tracerCore.CurrentPlayerState == PlayerState.Playing)
        {
            if (GUILayout.Button("Pause"))
            {
                tracerCore.CurrentPlayerState = PlayerState.Paused;
            }

            if (GUILayout.Button("Stop"))
            {
                tracerCore.StopPlay();

                tracerCore.CurrentPlayerState = PlayerState.Idle;
            }
        }
        else if (tracerCore.CurrentPlayerState == PlayerState.Paused)
        {
            if (GUILayout.Button("Resume"))
            {
                tracerCore.CurrentPlayerState = PlayerState.Playing;
            }

            if (GUILayout.Button("Stop"))
            {
                tracerCore.StopPlay();

                tracerCore.CurrentPlayerState = PlayerState.Idle;
            }
        }

        GUILayout.Label(string.Format("Recorder State: {0}", tracerCore.CurrentRecorderState.ToString()));

        if (tracerCore.CurrentRecorderState == RecorderState.Idle)
        {
            if (GUILayout.Button("Record"))
            {
                tracerCore.StartRecord();
                tracerCore.CurrentRecorderState = RecorderState.Recording;
            }
        }
        else if (tracerCore.CurrentRecorderState == RecorderState.Recording)
        {
            if (GUILayout.Button("Pause"))
            {
                tracerCore.CurrentRecorderState = RecorderState.Paused;
            }

            if (GUILayout.Button("Stop"))
            {
                tracerCore.StopRecord();
                tracerCore.CurrentRecorderState = RecorderState.Idle;
            }
        }
        else if (tracerCore.CurrentRecorderState == RecorderState.Paused)
        {
            if (GUILayout.Button("Resume"))
            {
                tracerCore.CurrentRecorderState = RecorderState.Recording;
            }

            if (GUILayout.Button("Stop"))
            {
                tracerCore.StopRecord();
                tracerCore.CurrentRecorderState = RecorderState.Idle;
            }
        }
    }
}
