using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField, Min(0f)] private float _jumpForce = 10;
    
    private Vector3 _startPosition;
    
    public event UnityAction Collided;
    public event UnityAction Triggered;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Collided?.Invoke();
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
