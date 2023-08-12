using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameObject Player;
    private Animator Anim;
    private SpriteRenderer Rend;
    private Transform Trans;
    private float _speed = 1.0f;
    private float _BackSpeed = -1.0f;
    private float _defaultSpeed = 1.0f;
    private float _defaultBackSpeed = -1.0f;
    private Rigidbody2D _body;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player");
        Rend = Player.GetComponent<SpriteRenderer>();
        Anim = Player.GetComponent<Animator>();
        Trans = Player.GetComponent<Transform>();
        _body = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetTrigger("Shot");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rend.flipX = false;

            _body.velocity = Trans.right * _speed;

            Anim.SetTrigger("Walk");
            //Trans.Translate(+ _speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rend.flipX= true;

            _body.velocity = Trans.right * _BackSpeed;

            Anim.SetTrigger("Walk");
            //Trans.Translate(- _speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetInteger("Run", 2);
            if (_speed <= _defaultSpeed)
            {
                _speed =+ _speed * 2;
                _BackSpeed = + _BackSpeed * 2;
                Debug.Log("GetKey" + _speed);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Anim.SetInteger("Run", 0);
            _speed = _defaultSpeed;
            _BackSpeed = _defaultBackSpeed; 
            Debug.Log("GetKeyUp" + _speed);
        }
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        //{
        //    Anim.SetInteger("Run", 0);
        //}
    }
}
