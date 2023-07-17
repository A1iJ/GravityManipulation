using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    private Animator animator;
    int isRunningHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool wPressed = Input.GetKey(KeyCode.W);
        bool aPressed = Input.GetKey(KeyCode.A);
        bool sPressed = Input.GetKey(KeyCode.S);
        bool dPressed = Input.GetKey(KeyCode.D);
        bool movementKeyPressed = wPressed || aPressed || sPressed || dPressed;

        if (!isRunning && movementKeyPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        if(isRunning && !movementKeyPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
