using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    public UnityAction Hited;
    
    [SerializeField] private Rigidbody2D _playerModel;
    [SerializeField] private ParticleSystem _glitters;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private int _flipRight = 0;
    private int _flipLeft = 160;

    private float _idleSpeed = 0;
    private float _speed = 1.0f;
    private float _runSpeed = 2;
    private float _jumpPower = 245.0f;
    private float _defaultSpeed = 1.0f;

    private float _timeWithoutJump;
    private float _jumpCooldown = 1;

    private int _shot = Animator.StringToHash("Shot");
    private int _walk = Animator.StringToHash("Walk");
    private int _fast = Animator.StringToHash("Fast");
    private int _jump = Animator.StringToHash("Jump");

    private void Start()
    {
        _animator = _playerModel.GetComponent<Animator>();
        _rigidbody2D = _playerModel.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        _timeWithoutJump += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(_shot);

            Hited?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_timeWithoutJump > _jumpCooldown)
            {
                _animator.SetTrigger(_jump);
                _rigidbody2D.AddForce(Vector2.up * _jumpPower);

                _timeWithoutJump = 0;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (_timeWithoutJump > _jumpCooldown)
            {
                transform.rotation = Quaternion.Euler(0, _flipRight, 0);

                _rigidbody2D.velocity = _playerModel.transform.right * _speed;

                _animator.SetTrigger(_walk);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (_timeWithoutJump > _jumpCooldown)
            {
                transform.rotation = Quaternion.Euler(0, _flipLeft, 0);

                _rigidbody2D.velocity = _playerModel.transform.right * _speed;

                _animator.SetTrigger(_walk);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_speed <= _defaultSpeed)
            {
                _speed = _speed * _runSpeed;

                _animator.SetFloat(_fast, _runSpeed);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetFloat(_fast, _idleSpeed);
            _speed = _defaultSpeed;
        }
    }

    private void OnMouseDown()
    {
        _glitters.Play();
    }
}
