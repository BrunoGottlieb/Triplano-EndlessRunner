using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = this.GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        InputManager.instance.OnJump += SetJump;
    }

    private void OnDisable()
    {
        InputManager.instance.OnJump -= SetJump;
    }

    private void SetJump()
    {
        _anim.SetTrigger("Jump");
    }

}
