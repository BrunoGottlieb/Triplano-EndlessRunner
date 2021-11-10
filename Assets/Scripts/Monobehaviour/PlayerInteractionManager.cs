using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInteractionManager : MonoBehaviour
{
    public CollectableOnUI coinUIEffect;

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
            _animationManager.SetDamage();
        }

        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
            coinUIEffect.PlayEffect(collectable.GetCollectableIndicator());
        }
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