using System.Collections;
using TMPro;
using UnityEngine;

public sealed class StatsSystem : MonoBehaviour
{
    private static StatsSystem _instance;
    public static StatsSystem Instance { get { return _instance; } }

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI distanceText;

    [Header("Targets")]
    [SerializeField] private Transform goldPos;
    [SerializeField] private Transform gemPos;
    [SerializeField] private Transform energyPos;

    private int _Gold { get; set; }
    private int _Gem { get; set; }
    private int _Energy { get; set; }
    private int _Distance { get; set; }
    public Vector2 GoldPosition { get { return goldPos.localPosition; } }
    public Vector2 GemPosition { get { return gemPos.localPosition; } }
    public Vector2 EnergyPosition { get { return energyPos.localPosition; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(IncreaseDistance());
    }

    private IEnumerator IncreaseDistance()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
            _Distance++;
            distanceText.text = _Distance.ToString("00000" + "m");
        }
    }

    public void UpdateGold(int value)
    {
        _Gold += value;
        goldText.text = _Gold.ToString();
    }

    public void UpdateGem(int value)
    {
        _Gem += value;
        gemText.text = _Gem.ToString();
    }

    public void UpdateEnergy(int value)
    {
        _Energy += value;
        energyText.text = _Energy.ToString();
    }

}
