using System.Collections;
using TMPro;
using UnityEngine;

public sealed class StatsSystem : MonoBehaviour
{
    public static StatsSystem Instance { get { return _instance; } }
    private static StatsSystem _instance;
    private Coroutine _measureDistanceCoroutine;

    [Header("Control")]
    [SerializeField] private int _maxEnergy;

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
    public int Energy { get; private set; }
    public int Distance { get; private set; }
    public Vector2 GoldPosition { get { return _goldPosition.localPosition; } }
    public Vector2 GemPosition { get { return _gemPosition.localPosition; } }
    public Vector2 EnergyPosition { get { return _energyPosition.localPosition; } }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (_instance != null && _instance != this)
        {
            Debug.Log("Not supposed to have more than 1 StatsSystem on scene");
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        InitializeEnergyText();
    }

    private void InitializeEnergyText()
    {
        _energyText.text = _maxEnergy.ToString() + "/" + _maxEnergy.ToString();
    }

    private IEnumerator IncreaseDistance()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
            Distance++;
            _distanceText.text = Distance.ToString("00000" + "m");
        }
    }

    private void ApplyTextScaleEffect(Transform obj)
    {
        obj.transform.LeanScale(new Vector3(1.5f, 1.5f, 1.5f), 0.25f);
        obj.transform.LeanScale(new Vector3(1, 1, 1), 0.2f).setDelay(0.25f);
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
        int newEnergy = Mathf.Clamp((Energy - value), 0, _maxEnergy);
        _energyText.text = newEnergy.ToString() + "/" + _maxEnergy.ToString();
        Energy = newEnergy;
    }
}
