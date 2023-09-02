using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Animator _anim;
    private SpriteRenderer _rend;
    private Transform _trans;
    private Rigidbody2D _body;

    private float _speed = 1.0f;
    private float _backSpeed = -1.0f;
    private float _defaultSpeed = 1.0f;
    private float _defaultBackSpeed = -1.0f;

    private int _shot = Animator.StringToHash("Shot");
    private int _walk = Animator.StringToHash("Walk");
    private int _run = Animator.StringToHash("Run");

    private void Start()
    {
        _rend = _player.GetComponent<SpriteRenderer>();
        _anim = _player.GetComponent<Animator>();
        _trans = _player.GetComponent<Transform>();
        _body = _player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetTrigger(_shot);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _rend.flipX = false;

            _body.velocity = _trans.right * _speed;

            _anim.SetTrigger(_walk);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _rend.flipX = true;

            _body.velocity = _trans.right * _backSpeed;

            _anim.SetTrigger(_walk);
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _anim.SetInteger(_run, 2);

            if (_speed <= _defaultSpeed)
            {
                _speed = +_speed * 2;
                _backSpeed = +_backSpeed * 2;
            }
        }
     
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _anim.SetInteger(_run, 0);
            _speed = _defaultSpeed;
            _backSpeed = _defaultBackSpeed;
        }
    }

    private void OnMouseDown()
    {
        _anim.SetTrigger(_shot);
    }
}
