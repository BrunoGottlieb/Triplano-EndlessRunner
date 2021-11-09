using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator _anim;

    public bool PlayerCanInteract { get { return _anim.GetBool("CanInteract"); } }

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
            _anim.SetTrigger("Jump");
        }
    }

    private void SetSlide()
    {
        if (PlayerCanInteract)
        {
            _anim.SetTrigger("Slide");
        }
    }

}
