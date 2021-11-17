using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    private Animator _anim;

    public bool PlayerCanInteract { get { return _anim.GetBool("CanInteract") && !_anim.GetBool("IsDead"); } }
    public bool IsJumping { get { return _anim.GetBool("IsJumping"); } }
    public bool IsSliding { get { return _anim.GetBool("IsSliding"); } }
    public bool IsDead { get { return _anim.GetBool("IsDead"); } }
    public bool IsRunning { get { return _anim.GetBool("IsRunning"); } }

    private void Awake()
    {
        _anim = this.GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        InputManager.Instance.OnJump += SetJump;
        InputManager.Instance.OnSlide += SetSlide;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnJump -= SetJump;
        InputManager.Instance.OnSlide -= SetSlide;
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

    public void Damage()
    {
        _anim.SetTrigger("Damage");
    }

    public void SetNotJumping() // Called on the heighest position of jump
    {
        _anim.SetBool("IsJumping", false);
    }

    public void StartRunning() // Called on first touch
    {
        _anim.SetBool("IsRunning", true);
    }

    public void Die()
    {
        if(!IsDead)
        {
            deathEffect.SetActive(true);
            _anim.SetBool("IsDead", true);
            _anim.SetBool("IsRunning", false);
        }
    }

}
