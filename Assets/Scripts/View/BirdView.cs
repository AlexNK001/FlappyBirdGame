using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdView : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _jumpForce = 10;
    private Rigidbody2D _rigidbody;

    public event UnityAction Died;
    public event UnityAction Triggered;

    private Vector3 _startPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Died?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Triggered?.Invoke();
    }

    public void Jump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Restart()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.position = _startPosition;
    }
}