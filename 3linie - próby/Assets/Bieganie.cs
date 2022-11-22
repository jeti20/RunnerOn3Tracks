using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bieganie : MonoBehaviour
{//https://www.youtube.com/watch?v=p89x1J06M-8
    private CharacterController _controller;
    private Vector3 _direction;
    public float _forwardSpeed;

    [SerializeField] private int _desireLane = 1; //0 lewo , 1 srodek, 2 prawo DesireLane MoveLeft Right
    [SerializeField] private float _lanedistance = 3;

    [SerializeField] bool _isGrounded;
    Vector3 _playerVelocity;
    [SerializeField]  float _jumpForce = 10f; 
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Logic();
        Movement();
        Jump();
    }

    void Logic()
    {
        //DesiderLane 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _desireLane++;
            if (_desireLane == 3)
            {
                _desireLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _desireLane--;
            if (_desireLane == -1)
            {
                _desireLane = 0;
            }
        }
    }

    void Movement()
    {
        _direction.z = _forwardSpeed;

        //calculate where we should be in the future
        Vector3 targetPosition = (transform.position.z * transform.forward) + (transform.position.y * transform.up);

        if (_desireLane == 0)
        {
            targetPosition += Vector3.left * _lanedistance;
        }
        else if (_desireLane == 2)
        {
            targetPosition += Vector3.right * _lanedistance;
        }

        transform.position = targetPosition;
        //transform.position = Vector3.Lerp(transform.position, targetPosition, laneSpeed * Time.deltaTime); //smooth
    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tor"))
        {
            _isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.forward * _forwardSpeed, ForceMode.Force);
        //_controller.Move(_direction * Time.fixedDeltaTime);
    }

}
