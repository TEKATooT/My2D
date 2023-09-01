using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject _player;
    private Animator _anim;
    private SpriteRenderer _rend;
    private Transform _trans;
    private float _speed = 1.0f;
    private float _backSpeed = -1.0f;
    private float _defaultSpeed = 1.0f;
    private float _defaultBackSpeed = -1.0f;
    private Rigidbody2D _body;

    void Start()
    {
        _player = GameObject.Find("player");
        _rend = _player.GetComponent<SpriteRenderer>();
        _anim = _player.GetComponent<Animator>();
        _trans = _player.GetComponent<Transform>();
        _body = _player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetTrigger("Shot");
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rend.flipX = false;

            _body.velocity = _trans.right * _speed;

            _anim.SetTrigger("Walk");
            //Trans.Translate(+ _speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rend.flipX = true;

            _body.velocity = _trans.right * _backSpeed;

            _anim.SetTrigger("Walk");
            //Trans.Translate(- _speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _anim.SetInteger("Run", 2);
            if (_speed <= _defaultSpeed)
            {
                _speed = +_speed * 2;
                _backSpeed = +_backSpeed * 2;
               // Debug.Log("GetKey" + _speed);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _anim.SetInteger("Run", 0);
            _speed = _defaultSpeed;
            _backSpeed = _defaultBackSpeed;
            // Debug.Log("GetKeyUp" + _speed);
        }
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        //{
        //    Anim.SetInteger("Run", 0);
        //}
    }

    private void OnMouseDown()
    {
        _anim.SetTrigger("Shot");
    }
}
