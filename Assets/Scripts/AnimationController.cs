using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnValidate()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
            
        }
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         PlayRun();
    //     }
    // }

    public void PlayIdle()
    {
        animator.Play("Idle");
    }

    public void PlayRun()
    {
        animator.Play("Run");
    }

    public void PlayJump()
    {
        animator.Play("Jump");
    }

    public void PlayJumpDown()
    {
        animator.Play("JumpDown");
    }

    public void PlayJumpDownLoop()
    {
        animator.Play("JumpDownLoop");
    }

    public void PlayDown()
    {
        animator.Play("Down");
    }
}
