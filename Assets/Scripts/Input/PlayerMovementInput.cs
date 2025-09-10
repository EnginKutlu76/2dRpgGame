using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private IPlayerInput _input;

    [Header("Movement Settings")]

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded;
    private bool _facingLeft = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        //_input = new KeyboardInput();
        _input = new NewInputSystemAdapter();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);

        HandleMovement();
        HandleJump();
        HandleFlip();
    }

    private void HandleMovement()
    {
        float move = _input.GetHorizontal();
        _rb.linearVelocity = new Vector2(move * _speed, _rb.linearVelocity.y);
    }

    private void HandleJump()
    {
        if (_isGrounded && _input.JumpPressed())
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }

    private void HandleFlip()
    {
        float move = _input.GetHorizontal();
        if ((_facingLeft && move > 0) || (!_facingLeft && move < 0))
        {
            _facingLeft = !_facingLeft;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnDrawGizmos()
    {
        if (_groundCheck != null)
            Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }
}

