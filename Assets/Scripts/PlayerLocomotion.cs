using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerManager playerManager;
    AnimatorManager animatorManager;
    InputManager inputManager;

    private AudioSource _audioSource;

    Vector3 moveDerection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingVelocity;
    public float rayCastHeightOffSet = 0.5f;
    public LayerMask groundLayer;

    [Header("Movement Flags")]
    public bool isSprinting;
    public bool isGrounded;
    public bool isJumping;

    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 5;
    public float sprintingSpeed = 7;
    public float rotationSpeed = 15;

    [Header("Jump Speeds")]
    public float jumpHeight = 3;
    public float gravityIntensity = -15;

    [Header("Player Sound")]
    public AudioClip footstepSound;
    public AudioClip runningSound;
    public AudioClip jumpingSound;
    public AudioClip landingSound;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<AnimatorManager>();
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;

        _audioSource = GetComponent<AudioSource>();
    }
    public void HandleAllMovement()
    {
        HandleFallingAndLanding();

        if (playerManager.isInteracting)
            return;

        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (isJumping)
            return;

        moveDerection = cameraObject.forward * inputManager.verticalInput;
        moveDerection = moveDerection + cameraObject.right * inputManager.horizontalInput;
        moveDerection.Normalize();
        moveDerection.y = 0;

        if (isSprinting)
        {
            moveDerection = moveDerection * sprintingSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)
            {
                moveDerection = moveDerection * runningSpeed;
            }
            else
            {
                moveDerection = moveDerection * walkingSpeed;
            }
        }

        Vector3 movementVelocity = moveDerection;
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        if (isJumping)
            return;

        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRottion = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRottion;
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        Vector3 targetPositoin;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffSet;
        targetPositoin = transform.position;

        if (!isGrounded && !isJumping)
        {
            if (!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Falling", true);
            }

            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * leapingVelocity);
            playerRigidbody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if (!isGrounded && !playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Landing", true);
            }

            Vector3 rayCastHitPoint = hit.point;
            targetPositoin.y = rayCastHitPoint.y;
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && !isJumping)
        {
            if (playerManager.isInteracting || inputManager.moveAmount > 0)
            {
                transform.position = Vector3.Lerp(transform.position, targetPositoin, Time.deltaTime / 0.1f);
            }
            else
            {
                transform.position = targetPositoin;
            }
        }
    }

    public void HandleJumping()
    {
        if (isGrounded)
        {
            animatorManager.animator.SetBool("isJumping", true);
            animatorManager.PlayTargetAnimation("Jump", false);

            float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVelocity = moveDerection;
            playerVelocity.y = jumpingVelocity;
            playerRigidbody.velocity = playerVelocity;
        }
    }

    public float volume = 0.5f;

    private void PlayFootstepSound()
    {
        AnimatorStateInfo stateInfo = animatorManager.animator.GetCurrentAnimatorStateInfo(0);

        float horizontal = animatorManager.animator.GetFloat("Horizontal");
        float vertical = animatorManager.animator.GetFloat("Vertical");

        bool isSlowRunning = (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f) && !isSprinting;

        if (footstepSound != null && !_audioSource.isPlaying && isGrounded && !isJumping && isSlowRunning)
        {
            _audioSource.PlayOneShot(footstepSound, volume);
        }
    }

    private void PlayRunningSound()
    {
        AnimatorStateInfo stateInfo = animatorManager.animator.GetCurrentAnimatorStateInfo(0);

        float horizontal = animatorManager.animator.GetFloat("Horizontal");
        float vertical = animatorManager.animator.GetFloat("Vertical");

        bool isRunning = (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f) && isSprinting;

        if (runningSound != null && !_audioSource.isPlaying && isGrounded && !isJumping && isRunning)
        {
            _audioSource.PlayOneShot(runningSound, volume);
        }
    }

    private void PlayJumpingSound()
    {
        AnimatorStateInfo stateInfo = animatorManager.animator.GetCurrentAnimatorStateInfo(0);

        if (jumpingSound != null && !_audioSource.isPlaying && isJumping && !isGrounded)
        {
            _audioSource.PlayOneShot(jumpingSound, volume);
        }
    }

    private void PlayLandingSound()
    {
        if (landingSound != null && !_audioSource.isPlaying && isGrounded)
        {
            _audioSource.PlayOneShot(landingSound, 1f);
        }
    }
}