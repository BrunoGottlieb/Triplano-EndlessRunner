using UnityEngine;
using UnityEngine.UI;

public sealed class CollectableOnUI : MonoBehaviour
{
    [SerializeField] private StatsSystem _statsSystem;
    private CollectableIndicatorData _indicator;
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

    public void PlayVisualEffect(CollectableIndicatorData indicator)
    {
        SetIndicatorIcon(indicator);
        this.gameObject.SetActive(true);
        SetIconPosition();
        IsMoving = true;
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
                return _statsSystem.GoldPosition;
            case "Gem":
                return _statsSystem.GemPosition;
            case "Energy":
                return _statsSystem.EnergyPosition;
            default:
                Debug.LogError("Target was not set on the CollectableIndicatorData");
                break;
        }
        return Vector2.zero;
    }

    private void UpdateStats()
    {
        switch (_indicator.type)
        {
            case "Gold":
                _statsSystem.UpdateGold(1);
                break;
            case "Gem":
                _statsSystem.UpdateGem(1);
                break;
            case "Energy":
                _statsSystem.UpdateEnergy(1);
                break;
            default:
                Debug.LogError("Type was not set on the CollectableIndicatorData");
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

    private void SetIndicatorIcon(CollectableIndicatorData indicator)
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
}
