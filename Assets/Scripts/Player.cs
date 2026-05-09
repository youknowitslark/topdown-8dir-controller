using UnityEngine;

public class Player : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField]
    private float _moveSpeed;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _movement;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        GetMovement();
        SetAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetMovement() 
    {
        _movement.x = Input.GetAxisRaw(HORIZONTAL);
        _movement.y = Input.GetAxisRaw(VERTICAL);
        _movement = _movement.normalized;
    }

    private void SetAnimation() 
    {
        _animator.SetFloat(VERTICAL, _movement.y);
        _animator.SetFloat(HORIZONTAL, _movement.x);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
    }

    private void Move() => _rb.linearVelocity = _movement * _moveSpeed;
}
