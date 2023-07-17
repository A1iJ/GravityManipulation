using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    public GroundCheck groundCheck;

    private Animator animator;
    public Animator hologramAnimator;

    int isRunningHash;
    int isGroundedHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isGroundedHash = Animator.StringToHash("isGrounded");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isGrounded = animator.GetBool(isGroundedHash);

        bool wPressed = Input.GetKey(KeyCode.W);
        bool aPressed = Input.GetKey(KeyCode.A);
        bool sPressed = Input.GetKey(KeyCode.S);
        bool dPressed = Input.GetKey(KeyCode.D);
        bool movementKeyPressed = wPressed || aPressed || sPressed || dPressed;

        //Movement
        if (!isRunning && movementKeyPressed)
        {
            animator.SetBool(isRunningHash, true);
            hologramAnimator.SetBool(isRunningHash, true);
        }

        if(isRunning && !movementKeyPressed)
        {
            animator.SetBool(isRunningHash, false);
            hologramAnimator.SetBool(isRunningHash, false);
        }

        //Jumping
        if (groundCheck.isGrounded)
        {
            animator.SetBool(isGroundedHash, true);
            hologramAnimator.SetBool(isGroundedHash, true);
        }

        if (!groundCheck.isGrounded)
        {
            animator.SetBool(isGroundedHash, false);
            hologramAnimator.SetBool(isGroundedHash, false);
        }
    }
}
