using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private float _speed = 1.0f;
    private float _backSpeed = -1.0f;
    private float _defaultSpeed = 1.0f;
    private float _defaultBackSpeed = -1.0f;

    private int _shot = Animator.StringToHash("Shot");
    private int _walk = Animator.StringToHash("Walk");
    private int _run = Animator.StringToHash("Run");

    private void Start()
    {
        _spriteRenderer = _gameObject.GetComponent<SpriteRenderer>();
        _animator = _gameObject.GetComponent<Animator>();
        _rigidbody2D = _gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(_shot);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            _rigidbody2D.velocity = _gameObject.transform.right * _speed;

            _animator.SetTrigger(_walk);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            _rigidbody2D.velocity = _gameObject.transform.right * _backSpeed;

            _animator.SetTrigger(_walk);
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetInteger(_run, 2);

            if (_speed <= _defaultSpeed)
            {
                _speed = +_speed * 2;
                _backSpeed = +_backSpeed * 2;
            }
        }
     
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetInteger(_run, 0);
            _speed = _defaultSpeed;
            _backSpeed = _defaultBackSpeed;
        }
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger(_shot);
    }
}
