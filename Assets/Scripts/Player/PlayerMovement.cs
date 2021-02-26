using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float footStepTimer;

    public Transform groundCheck;
    public LayerMask groundMask;

    private PlayerSound playerSound;

    Vector3 velocity;
    bool isGrounded = true;
    bool isWalking = false;
    bool isJumping = false;
    bool isRunning = false;
    bool isSoundPlaying = false;
    bool isSoundJumpPlaying = false;

     public bool IsGrounded { get; }

    // Start is called before the first frame update
    void Start()
    {
        playerSound = GetComponent<PlayerSound>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Move();
    }

    private void Move() {
        if (isSoundJumpPlaying && !playerSound.audioSource.isPlaying)
        {
            isSoundJumpPlaying = false;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

            if (isJumping)
            {
                StopCoroutine("PlayStepSound");
                isJumping = false;
                playerSound.audioSource.clip = playerSound.GetJumpLandingSound();
                playerSound.audioSource.Play();

                isSoundJumpPlaying = true;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately(x, 0);
        bool hasVerticalInput = !Mathf.Approximately(z, 0);
        isWalking = hasHorizontalInput || hasVerticalInput;

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftControl) && isWalking)
        {   
            Debug.Log("Corriendo");
            isWalking = false;
            if (!isRunning)
            {
                StopCoroutine("PlayStepSound");
                isSoundPlaying = false;
            }

            isRunning = true;
            controller.Move(move * speed * speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Andando");
            if (isRunning)
            {
                StopCoroutine("PlayStepSound");
                isSoundPlaying = false;
            }
            
            isRunning = false;
            controller.Move(move * speed * Time.deltaTime);
        }

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }

        if (isGrounded && isWalking && !isSoundPlaying && !isSoundJumpPlaying)
        {
            PlayFootSound();
        }
        if (isGrounded && isRunning && !isSoundPlaying && !isSoundJumpPlaying)
        {
            PlayFootSound();
        }

        velocity.y += gravity * Time.deltaTime;

        // Se multiplica otra vez por time.deltatime para cumplir con la formula fisica (incremento en y = 1/2 * g * t^2)
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayFootSound()
    {
        float time = (isRunning ? footStepTimer / 2 : footStepTimer);
        StartCoroutine("PlayStepSound", time);
    }

    private IEnumerator PlayStepSound(float timer)
    {
        playerSound.audioSource.clip = playerSound.GetNextSound();
        playerSound.audioSource.Play();

        isSoundPlaying = true;

        yield return new WaitForSeconds(timer);

        isSoundPlaying = false;
    }
}
