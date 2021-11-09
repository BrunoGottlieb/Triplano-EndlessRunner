using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMovementManager : MonoBehaviour
{
    public Transform bodyJumper;
    private PlayerAnimationManager _animator;

    private void Awake()
    {
        _animator = this.GetComponent<PlayerAnimationManager>();
    }
    public void Move(float speed, Vector3 destination) // Called by Player Controller FixedUpdate | Change between lanes
    {
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }

    public void Jump(float fallSpeed, float jumpHeight, float jumpSpeed)
    {
        if (_animator.IsJumping) // Move up
        {
            float step = jumpSpeed * Time.deltaTime; // Jump speed

            bodyJumper.transform.localPosition = Vector3.MoveTowards(bodyJumper.localPosition, new Vector3(0,jumpHeight,0), step);
        
            if(bodyJumper.localPosition.y >= jumpHeight) // Check maximum height
            {
                _animator.SetNotJumping(); // Not jumping anymore
            }
        }
        else // Not jumping, move down
        {
            float step = fallSpeed * Time.deltaTime; // Gravity

            bodyJumper.transform.localPosition = Vector3.MoveTowards(bodyJumper.localPosition, Vector3.zero, step);
        }
    }

    public void Slide()
    {
        /// Not necessary
    }

}
