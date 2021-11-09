using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInteractionManager : MonoBehaviour
{
    private PlayerController _controller;
    private PlayerAnimationManager _animationManager;

    private void Awake()
    {
        _controller = this.GetComponent<PlayerController>();
        _animationManager = this.GetComponent<PlayerAnimationManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IObstacle obstacle = other.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            print("Death");
            _animationManager.SetDamage();
        }

        ICollectable collectable = other.GetComponent<ICollectable>();
        collectable?.Collect();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Lane>() != null) // Player is on a lane
        {
            _controller.CanChangeLane = true;
        }
    }

    private void OnTriggerExit(Collider other) // Player can't interact while changing lane
    {
        _controller.CanChangeLane = false;
    }
}
