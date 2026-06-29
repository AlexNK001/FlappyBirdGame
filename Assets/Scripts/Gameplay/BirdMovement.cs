using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMovement : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _jumpForce;
    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition;
    private EventBus _bus;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    [Inject]
    private void Construct(EventBus bus)
    {
        _bus = bus;
        _bus.JumpRequested.Invoked += OnJump;
        _bus.Restarted.Invoked += OnRestart;
    }

    private void OnDestroy()
    {
        _bus.JumpRequested.Invoked -= OnJump;
        _bus.Restarted.Invoked -= OnRestart;
    }

    private void OnJump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnRestart()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.position = _startPosition;
    }
}