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
    bool isSoundPlaying = false;

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
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

            if (isJumping)
            {
                isJumping = false;
                playerSound.audioSource.clip = playerSound.GetNextSound();
                playerSound.audioSource.Play();
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately(x, 0);
        bool hasVerticalInput = !Mathf.Approximately(z, 0);
        isWalking = hasHorizontalInput || hasVerticalInput;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }

        if (isGrounded && isWalking && !isSoundPlaying)
        {
            PlayFootSound();
        }

        velocity.y += gravity * Time.deltaTime;

        // Se multiplica otra vez por time.deltatime para cumplir con la formula fisica (incremento en y = 1/2 * g * t^2)
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayFootSound()
    {
        StartCoroutine("PlayStepSound", footStepTimer);
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
