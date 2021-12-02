using UnityEngine;

public sealed class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffect;
    private PlayerHealthHandler _healthHandler;
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

    private void OnEnable()
    {
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
    }

    public void Init()
    {
        _anim = this.GetComponentInChildren<Animator>();
        _healthHandler = this.GetComponent<PlayerHealthHandler>();
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

    private void SubscribeToEvents()
    {
        _healthHandler.OnTakeDamage += PlayDamageAnimation;
        _healthHandler.OnDeath += PlayDeathAnimation;
    }

    private void UnsubscribeToEvents()
    {
        _healthHandler.OnTakeDamage -= PlayDamageAnimation;
        _healthHandler.OnDeath -= PlayDeathAnimation;
    }
}
