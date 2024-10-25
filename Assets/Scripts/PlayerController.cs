using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _movimentSpeed = 5;

    private float _horizontal;
    private float _vertical;


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
    }
    void Movement()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);

        _controller.Move(direction * _movimentSpeed * Time.deltaTime);
    }
}
