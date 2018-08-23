using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class XBoxOneController : MonoBehaviour {
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state, prevState;

    float rotationX = 0.0f, rotationY = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }
        prevState = state;
        state = GamePad.GetState(playerIndex);

        var rotateVector = new Vector2(state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y);

        float sensitivityX = 5.0f, sensitivityY = 5.0f;
        float minRotationY = -80.0f, maxRotationY = 80.0f;

        rotationX = transform.localEulerAngles.y + rotateVector.x * sensitivityX;
        rotationY += rotateVector.y * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX);

        transform.localPosition +=
            state.ThumbSticks.Right.Y * transform.forward * 50.0f * Time.deltaTime
            + state.ThumbSticks.Right.X * transform.right * 50.0f * Time.deltaTime;
    }
}
