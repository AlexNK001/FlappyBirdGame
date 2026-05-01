using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _pause = KeyCode.Escape;

    public event UnityAction Jumped;
    public event UnityAction Paused;

    private void Update()
    {
        if (Input.GetKeyDown(_jump))
        {
            Jumped?.Invoke();
        }

        if (Input.GetKeyDown(_pause))
        {
            Paused?.Invoke();
        }
    }
}