using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Min(0f)] 
    private float _speed;

    [SerializeField] 
    private Transform _groundCheck;

    [SerializeField] 
    private LayerMask _groundLayerMask;
    
    private CharacterController _playerController;
    private Vector3 _velocity;
    private float _gravity = -9.81f;
    private float _groundCheckRadius = 0.2f;
    private bool _isGrounded;
    

    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundLayerMask);
        
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        else
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
             

        Vector3 move = transform.right * xDirection + transform.forward * zDirection;
        _playerController.Move(move * _speed * Time.deltaTime);
        _playerController.Move(_velocity * Time.deltaTime);
    }
}
