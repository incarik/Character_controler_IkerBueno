using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _movimentSpeed = 5;

    private float _horizontal;
    private float _vertical;

    //--------------Cosas Gravedad--------------------

    [SerializeField] private float  _gravity = -9.81f;
    [SerializeField] private Vector3 _playerGravity;
    
    //--------------Cosas GroundSensor----------------
    [SerializeField] Transform _sensorPosition;
    [SerializeField] float _sensorRadius = 0.5f;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] private bool _isGrounded;
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        Movement();

        Gravity();
    }
    void Movement()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);

        _controller.Move(direction * _movimentSpeed * Time.deltaTime);
    }

    void Gravity()
    {
        if(!_isGrounded)
        {
            _playerGravity.y += _gravity * Time.deltaTime;
        }
        else if(_isGrounded && _playerGravity.y < 0)
        {
            _playerGravity.y = -1;
        }
       
        _controller.Move(_playerGravity * Time.deltaTime);
    }

    void IsGrounded()
    {
        if(Physics.CheckSphere(_sensorPosition.position, _sensorRadius, _groundLayer))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
