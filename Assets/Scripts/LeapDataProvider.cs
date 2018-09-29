﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity;
using Leap;

public class LeapDataProvider : LeapProvider
{
	public Frame[] savedFrame;
	private static LeapDataProvider instance;
	public static LeapDataProvider getInstance()
	{
		return instance;
	}

	void Awake()
	{
		instance = this;
	}
	int cursor = 0;
	bool replayStarted = false;

    public override Frame CurrentFrame
    {
        get
        {
			if(cursor >= 0 && cursor < savedFrame.Length)
            	return savedFrame[cursor];
			return new Frame();
        }
    }

    public override Frame CurrentFixedFrame 
	{
		get
		{
			return CurrentFrame;
		}
	}

	public void StartReplay()
	{
		cursor = 0;
		replayStarted = true;
	}
	void Update()
	{
		DispatchUpdateFrameEvent(CurrentFrame);
	}

	void FixedUpdate()
	{
		if(replayStarted)
		{
			cursor++;
			if(cursor == savedFrame.Length)
			{
				cursor = savedFrame.Length-1;
			}
		}
		DispatchFixedFrameEvent(CurrentFrame);
	}

}
