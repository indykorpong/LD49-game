using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Animator Animator => animator;

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

    private void ResetAllBooleans()
    {
        string[] animBooleans = {"Idle", "Run", "JumpUp", "JumpPeak", "JumpDownLoop"};
        foreach (string animBoolean in animBooleans)
        {
            animator.SetBool(animBoolean, false);
        }
    }

    public void PlayIdle()
    {
        ResetAllBooleans();
        animator.SetBool("Idle", true);
    }

    public void PlayRun()
    {
        ResetAllBooleans();
        animator.SetBool("Run", true);
    }

    public void PlayJumpUp()
    {
        ResetAllBooleans();
        animator.SetBool("JumpUp", true);
    }

    public void PlayJumpPeak()
    {
        ResetAllBooleans();
        animator.SetBool("JumpPeak", true);
    }

    public void PlayJumpDownLoop()
    {
        ResetAllBooleans();
        animator.SetBool("JumpDownLoop", true);
    }

    // public void PlayDown()
    // {
    //     ResetAllBooleans();
    //     animator.Play("Down");
    // }
}
