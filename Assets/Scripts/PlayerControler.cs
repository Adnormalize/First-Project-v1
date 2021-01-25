using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [Header(" ")]
    [SerializeField] private bool _thereIsAKey = false;

    [Header(" ")]
    [SerializeField] private int _health = 100;

    private bool _isGrounded;
    private Rigidbody _rigidBody;
    private Collider _InteractsWith;
    private Animation _animationGameObject;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractingWithObjects(_InteractsWith);
        }
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    #region TriggerAndCollosoin
    private void OnTriggerEnter(Collider trigger)
    {
        _InteractsWith = trigger;
    }

    private void OnTriggerExit(Collider trigger)
    {
        _InteractsWith = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
    }

    #endregion

    #region Functions

    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = value;
        }
    }
    private void Movement()
    {
        float _moveHorizontal = Input.GetAxis("Horizontal");
        float _moveVertical = Input.GetAxis("Vertical");

        Vector3 _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);

        _rigidBody.AddForce(_movement * _speed);
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rigidBody.AddForce(Vector3.up * _jumpForce);
            }
        }
    }
    private void InteractingWithObjects(Collider trigger)
    {
        if (trigger == null)
        {
            return;
        }
        else
        {
            if (trigger.gameObject.tag == "Key")
            {
                _thereIsAKey = true;
                Destroy(trigger.gameObject);
            }
            else if (trigger.gameObject.tag == "Medicine")
            {
                _health += 50;
                Destroy(trigger.gameObject);
            }

            if (trigger.gameObject.tag == "Door")
            {
                if (_thereIsAKey == true)
                {
                    _animationGameObject = trigger.gameObject.GetComponent<Animation>();
                    _animationGameObject.Play();
                }
            }
        }
    }

    #endregion
}
