using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private CollectableOnUI[] _coinUIEffect;
    [SerializeField] private LeadboardScreen _leadboardScreen;

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
            int damage = obstacle.TakeDamage();
            int newLifeValue = StatsSystem.Instance.ApplyDamage(damage);
            if(newLifeValue > 0)
            {
                _animationManager.Damage();
            }
            else
            {
                _animationManager.Die();
                CameraShaker.Instance.Shake(2, 5, 0.2f);
                BlockSpawner.Instance.StopAllBlocks();
                _leadboardScreen.gameObject.SetActive(true);
            }
        }

        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            if(!collectable.HasBeenCollected)
            {
                collectable.Collect();
                CollectableOnUI effect = !_coinUIEffect[0].isMoving ? _coinUIEffect[0] : _coinUIEffect[1];
                effect.PlayEffect(collectable.GetCollectableIndicator());
            }
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
