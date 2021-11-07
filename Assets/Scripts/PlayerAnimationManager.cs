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

    private void Start()
    {
        //_anim.SetBool("isRunning", true);
    }

}
