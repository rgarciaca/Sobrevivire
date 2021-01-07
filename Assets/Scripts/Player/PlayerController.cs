using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedCustomizableSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed;
    public int angleRotationThreshold;
    public float JumpHeight = 2f;
    public float gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;    

    private bool _isGrounded = true;
    private bool temporaryMovementTriggered = false;
    private float temporaryDesiredRotation;
    private Animator _animator;
    private CharacterController _controller;
    private Vector3 _velocity;
    private Transform _groundChecker;
    private Quaternion endRotationY;


    protected Vector3 moveDirection = Vector3.zero;
    protected float desiredRotationAngle = 0;

      
    void Start()
    {
        _animator = GetComponent<CharacterCustomization>().animators[0];
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        _animator.SetBool("walk", isWalking);

        Vector3 move = new Vector3(horizontal, 0, vertical);
        move.Normalize();
        HandleMovement(move);
        HandleMovementDirection(Vector3.Scale(Camera.main.transform.forward, (Vector3.right + Vector3.forward)));

        _controller.Move(moveDirection * Time.deltaTime);
        //if (moveDirection != Vector3.zero)
        //    transform.forward = moveDirection;

        if (Input.GetButtonDown("Jump") && _isGrounded)
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * gravity);

        if (_isGrounded)
        {
            if (moveDirection.magnitude > 0)
            {
                //var animationSpeedMultiplier = SetCorrectAnimation(desiredRotationAngle, angleRotationThreshold, inputVerticalDirection);
                if (!temporaryMovementTriggered)
                {
                    RotateAgent();
                }
                else
                {
                    RotateTemp();
                }
                
                //moveDirection *= animationSpeedMultiplier;
            }
        }

        _velocity.y += gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

    public void HandleMovement(Vector3 input) 
    {
        if (_isGrounded)
        {
            if (input.z != 0)
            {
                temporaryMovementTriggered = false;
                moveDirection = input.z * transform.forward * speed;
            }
            else 
            {
                if (input.x != 0)
                {
                    if (!temporaryMovementTriggered)
                    {
                        temporaryMovementTriggered = true;

                        int directionParameter = input.x > 0 ? 1 : -1;
                        if (directionParameter > 0)
                        {
                            temporaryDesiredRotation = 90;
                        }
                        else 
                        {
                            temporaryDesiredRotation = -90;
                        }
                        endRotationY = Quaternion.Euler(transform.localEulerAngles) * Quaternion.Euler(Vector3.up * temporaryDesiredRotation);
                    }
                    moveDirection = transform.forward * speed;
                }
                else
                {
                    temporaryMovementTriggered = false;
                    _animator.SetBool("walk", false);
                    moveDirection = Vector3.zero;
                }
            }
        }
    }

    public void HandleMovementDirection(Vector3 input)
    {
        if (temporaryMovementTriggered)
        {
            return;
        }
        desiredRotationAngle = Vector3.Angle(transform.forward, input);
        var crossProduct = Vector3.Cross(transform.forward, input).y;
        if (crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateTemp()
    {
        desiredRotationAngle = Quaternion.Angle(transform.rotation, endRotationY);
        if (desiredRotationAngle > angleRotationThreshold || desiredRotationAngle < -angleRotationThreshold)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, endRotationY, Time.deltaTime * rotationSpeed * 100);
        }
    }

    private void RotateAgent()
    {
        if (desiredRotationAngle > angleRotationThreshold || desiredRotationAngle < -angleRotationThreshold)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

}
