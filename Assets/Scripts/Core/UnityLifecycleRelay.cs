using System;
using UnityEngine;

public class UnityLifecycleRelay : MonoBehaviour
{
    public event Action Started;
    public event Action Destroyed;

    private void Start()
    {
        Started?.Invoke();
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke();
    } 
}