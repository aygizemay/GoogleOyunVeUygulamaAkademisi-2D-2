using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cc : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 100f;

    Rigidbody2D _rigidbody2d;
    Animator _animator;
    bool started;
    bool grounded;
    bool jumping;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (started && grounded)
            {
                _animator.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                started = true;
            }
        }
        _animator.SetBool("Grounded", grounded);
    }
    private void FixedUpdate()
    {
        if (started)
        {
            _rigidbody2d.velocity = new Vector2(speed, _rigidbody2d.velocity.y);
        }

        if (jumping)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, jumpForce);
            jumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
