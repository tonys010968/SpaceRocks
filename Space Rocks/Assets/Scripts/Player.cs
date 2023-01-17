using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    private Rigidbody2D _rigidBody;
    private bool _thrusting;
    private float _turnDirection;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        } else
        {
            _turnDirection = 0.0f;  
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rigidBody.AddForce(this.transform.up * thrustSpeed); 
        }
        if (_turnDirection != 0.0f)
        {
            _rigidBody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }
}
