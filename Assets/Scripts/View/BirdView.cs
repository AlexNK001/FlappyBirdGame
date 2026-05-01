using UnityEngine;
using UnityEngine.Events;

public class BirdView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField, Min(0f)] private float _jumpForce = 10;

    public event UnityAction Died;
    public event UnityAction Triggered;

    private Vector3 _startPosition;

    public void Initialization()
    {
        _startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Died.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Triggered.Invoke();
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