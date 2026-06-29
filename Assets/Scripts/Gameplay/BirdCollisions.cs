using System;
using UnityEngine;

public class BirdCollisions : MonoBehaviour, IBirdCollisions
{
    public event Action ScoreZoneTriggered;
    public event Action PlayerDied;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<KillZone>(out _))
        {
            PlayerDied?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ScoreZone>(out _))
        {
            ScoreZoneTriggered?.Invoke();
        }
    }
}