using UnityEngine;
using UnityEngine.UI;

public sealed class CollectableOnUI : MonoBehaviour
{
    private CollectableIndicator _indicator;
    private Vector2 _targetPos;
    private Image _image;

    public bool IsMoving { get; private set; }

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
        _image = this.GetComponent<Image>();
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
                Debug.LogError("Target was not set on the CollectableIndicator");
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
                Debug.LogError("Type was not set on the CollectableIndicator");
                break;
        }

    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (ReachedTargetPosition())
        {
            UpdateStats();
            IsMoving = false;
            this.gameObject.SetActive(false);
        }
    }

    private bool ReachedTargetPosition()
    {
        return Vector2.Distance(this.transform.localPosition, _targetPos) < 10;
    }

    private void SetIndicatorIcon(CollectableIndicator indicator)
    {
        _indicator = indicator;
        _image.sprite = indicator.icon;
    }

    private void SetIconPosition()
    {
        _targetPos = GetTargetPosition();
        transform.localPosition = Vector3.zero;
        transform.LeanMoveLocal(_targetPos, 0.2f);
    }

    public void PlayVisualEffect(CollectableIndicator indicator)
    {
        SetIndicatorIcon(indicator);
        this.gameObject.SetActive(true);
        SetIconPosition();
        IsMoving = true;
    }
}
