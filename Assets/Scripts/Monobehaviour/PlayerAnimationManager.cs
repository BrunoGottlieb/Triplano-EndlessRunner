using UnityEngine;

public sealed class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;
    private Animator _anim;
    public bool PlayerCanInteract { get { return _anim.GetBool("CanInteract") && !_anim.GetBool("IsDead"); } }
    public bool IsJumping { get { return _anim.GetBool("IsJumping"); } }
    public bool IsSliding { get { return _anim.GetBool("IsSliding"); } }
    public bool IsDead { get { return _anim.GetBool("IsDead"); } }
    public bool IsRunning { get { return _anim.GetBool("IsRunning"); } }
    public bool IsStanding { get { return !IsJumping && !IsSliding && PlayerCanInteract; } }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _anim = this.GetComponentInChildren<Animator>();
    }

    public void PlayJumpAnimation()
    {
        _anim.SetBool("IsJumping", true);
    }

    public void PlaySlideAnimation()
    {
        _anim.SetBool("IsSliding", true);
    }

    public void SetNotJumping() // Called on the heighest position of jump
    {
        _anim.SetBool("IsJumping", false);
    }

    public void StartRunning() // Called on first touch
    {
        _anim.SetBool("IsRunning", true);
    }

    public void PlayDamageAnimation()
    {
        _anim.SetTrigger("Damage");
    }

    public void PlayDeathAnimation()
    {
        _deathEffect.SetActive(true);
        _anim.SetBool("IsDead", true);
        _anim.SetBool("IsRunning", false);
        _deathEffect.SetActive(true);
    }

}
