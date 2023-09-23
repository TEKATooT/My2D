using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private int _idleSpeed = 0;
    private int _runSpeed = 2;

    private float _speed = 1.0f;
    private float _jumpPower = 5.0f;
    private float _backSpeed = -1.0f;
    private float _defaultSpeed = 1.0f;
    private float _defaultBackSpeed = -1.0f;

    private int _shot = Animator.StringToHash("Shot");
    private int _walk = Animator.StringToHash("Walk");
    private int _run = Animator.StringToHash("Run");
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(_shot);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetTrigger(_jump);

            _rigidbody2D.velocity = _player.transform.up * _jumpPower;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            _rigidbody2D.velocity = _player.transform.right * _speed;

            _animator.SetTrigger(_walk);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            _rigidbody2D.velocity = _player.transform.right * _backSpeed;

            _animator.SetTrigger(_walk);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_speed <= _defaultSpeed)
            {
                _speed = _speed * _runSpeed;
                _backSpeed = _backSpeed * _runSpeed;

                _animator.SetInteger(_run, _runSpeed);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetInteger(_run, _idleSpeed);
            _speed = _defaultSpeed;
            _backSpeed = _defaultBackSpeed;
        }
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger(_shot);
    }
}
