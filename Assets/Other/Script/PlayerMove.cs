using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private float _idleSpeed = 0;
    private float _speed = 1.0f;
    private float _runSpeed = 2;
    private float _jumpPower = 245.0f;
    private float _backSpeed = -1.0f;
    private float _defaultSpeed = 1.0f;
    private float _defaultBackSpeed = -1.0f;
    private float _jumpCoolDown;

    private int _shot = Animator.StringToHash("Shot");
    private int _walk = Animator.StringToHash("Walk");
    private int _fast = Animator.StringToHash("Fast");
    private int _jump = Animator.StringToHash("Jump");

    private void Start()
    {
        _animator = _player.GetComponent<Animator>();
        _spriteRenderer = _player.GetComponent<SpriteRenderer>();
        _rigidbody2D = _player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        _jumpCoolDown += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(_shot);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_jumpCoolDown > 1)
            {
                _animator.SetTrigger(_jump);
                _rigidbody2D.AddForce(Vector2.up * _jumpPower);

                _jumpCoolDown = 0;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (_jumpCoolDown > 1)
            {
                _spriteRenderer.flipX = false;

                _rigidbody2D.velocity = _player.transform.right * _speed;

                _animator.SetTrigger(_walk);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (_jumpCoolDown > 1)
            {
                _spriteRenderer.flipX = true;

                _rigidbody2D.velocity = _player.transform.right * _backSpeed;

                _animator.SetTrigger(_walk);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_speed <= _defaultSpeed)
            {
                _speed = _speed * _runSpeed;
                _backSpeed = _backSpeed * _runSpeed;

                _animator.SetFloat(_fast, _runSpeed);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetFloat(_fast, _idleSpeed);
            _speed = _defaultSpeed;
            _backSpeed = _defaultBackSpeed;
        }
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger(_shot);
    }
}
