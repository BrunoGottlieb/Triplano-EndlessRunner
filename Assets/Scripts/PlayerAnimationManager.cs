using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerAnimationManager : MonoBehaviour
{
    private Animator _anim;

    public bool PlayerCanInteract { get { return _anim.GetBool("CanInteract"); } }
    public bool IsJumping { get { return _anim.GetBool("IsJumping"); } }
    public bool IsSliding { get { return _anim.GetBool("IsSliding"); } }

    private void Awake()
    {
        _anim = this.GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        InputManager.instance.OnJump += SetJump;
        InputManager.instance.OnSlide += SetSlide;
    }

    private void OnDisable()
    {
        InputManager.instance.OnJump -= SetJump;
        InputManager.instance.OnSlide -= SetSlide;
    }

    private void SetJump()
    {
        if(PlayerCanInteract)
        {
            _anim.SetBool("IsJumping", true);
        }
    }

    private void SetSlide()
    {
        if (PlayerCanInteract)
        {
            _anim.SetBool("IsSliding", true);
        }
    }

    public void SetNotJumping() // Called on the heighest position of jump
    {
        _anim.SetBool("IsJumping", false);
    }

    public void Die()
    {
        _anim.SetBool("IsDead", true);
    }

}
