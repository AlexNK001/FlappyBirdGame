using System;
using UnityEngine;

public class UserInput : MonoBehaviour, IUserInput
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;

    public event Action Jumped;
    public event Action Paused;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            Jumped?.Invoke();
        }

        if (Input.GetKeyDown(_pauseKey))
        {
            Paused?.Invoke();
        }
    }
}