using System.Collections;
using TMPro;
using UnityEngine;

public sealed class StatsSystem : MonoBehaviour
{
    private Coroutine _measureDistanceCoroutine;

    [Header("Scripts")]
    [SerializeField] private PlayerHealthHandler _playerHealthHandler;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _gemText;
    [SerializeField] private TextMeshProUGUI _energyText;
    [SerializeField] private TextMeshProUGUI _distanceText;

    [Header("Targets")]
    [SerializeField] private Transform _goldPosition;
    [SerializeField] private Transform _gemPosition;
    [SerializeField] private Transform _energyPosition;

    public int Gold { get; private set; }
    public int Gem { get; private set; }
    public int Distance { get; private set; }
    public Vector2 GoldPosition { get { return _goldPosition.localPosition; } }
    public Vector2 GemPosition { get { return _gemPosition.localPosition; } }
    public Vector2 EnergyPosition { get { return _energyPosition.localPosition; } }
    public int Energy {
        get { return _playerHealthHandler.CurrentHealth; }
        set { _playerHealthHandler.SetHealthValue(value); }
    }

    private void Start()
    {
        InitializeEnergyText();
    }

    public void StartMeasuringDistance() // Called by player's touch on screen
    {
        _measureDistanceCoroutine = StartCoroutine(IncreaseDistance());
    }

    public void StopMeasuringDistance() // Called by PlayerController when it's dead
    {
        StopCoroutine(_measureDistanceCoroutine);
    }

    public void UpdateGold(int value)
    {
        Gold += value;
        _goldText.text = Gold.ToString();
        ApplyTextScaleEffect(_goldText.transform);
    }

    public void UpdateGem(int value)
    {
        Gem += value;
        _gemText.text = Gem.ToString();
        ApplyTextScaleEffect(_gemText.transform);
    }

    public void UpdateEnergy(int value)
    {
        Energy += value;
        _energyText.text = Energy.ToString();
        ApplyTextScaleEffect(_energyText.transform);
    }

    public void ApplyDamage(int value)
    {
        int newEnergy = Mathf.Clamp((Energy - value), 0, _playerHealthHandler.MaxHealth);
        _energyText.text = newEnergy.ToString() + "/" + _playerHealthHandler.MaxHealth.ToString();
        Energy = newEnergy;
    }

    private void InitializeEnergyText()
    {
        _energyText.text = _playerHealthHandler.CurrentHealth.ToString() + "/" + _playerHealthHandler.MaxHealth.ToString();
    }

    private void ApplyTextScaleEffect(Transform obj)
    {
        obj.transform.LeanScale(new Vector3(1.5f, 1.5f, 1.5f), 0.25f);
        obj.transform.LeanScale(new Vector3(1, 1, 1), 0.2f).setDelay(0.25f);
    }

    private IEnumerator IncreaseDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            Distance++;
            _distanceText.text = Distance.ToString("00000" + "m");
        }
    }
}
