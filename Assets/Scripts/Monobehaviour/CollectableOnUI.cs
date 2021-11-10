using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollectableOnUI : MonoBehaviour
{
    private CollectableIndicator _indicator;
    private Vector2 _targetPos;
    private Image _image;

    private void Awake()
    {
        _image = this.GetComponent<Image>();
    }

    public void PlayEffect(CollectableIndicator indicator)
    {
        _indicator = indicator;
        _image.sprite = indicator.icon;
        _targetPos = GetTargetPosition();
        this.gameObject.SetActive(true);
        transform.localPosition = Vector3.zero;
        transform.LeanMoveLocal(_targetPos, 0.2f);
    }

    private Vector2 GetTargetPosition()
    {
        switch (_indicator.type)
        {
            case "Gold":
                return StatsSystem.Instance.GoldPosition;
            case "Gem":
                return StatsSystem.Instance.GemPosition;
            case "Energy":
                return StatsSystem.Instance.EnergyPosition;
            default:
                Debug.Log("Type was not set on the CollectableIndicator");
                break;
        }
        return Vector2.zero;
    }

    private void UpdateStats()
    {
        switch (_indicator.type)
        {
            case "Gold":
                StatsSystem.Instance.UpdateGold(1);
                break;
            case "Gem":
                StatsSystem.Instance.UpdateGem(1);
                break;
            case "Energy":
                StatsSystem.Instance.UpdateEnergy(1);
                break;
            default:
                Debug.Log("Type was not set on the CollectableIndicator");
                break;
        }

    }

    private void Update()
    {
        if(Vector2.Distance(this.transform.localPosition, _targetPos) < 0.1f)
        {
            UpdateStats();
            this.gameObject.SetActive(false);
        }
    }
}
