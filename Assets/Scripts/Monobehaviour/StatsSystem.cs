using System.Collections;
using TMPro;
using UnityEngine;

public sealed class StatsSystem : MonoBehaviour
{
    private static StatsSystem _instance;
    public static StatsSystem Instance { get { return _instance; } }
    [SerializeField] private PlayerAnimationManager player;

    [Header("Control")]
    [SerializeField] private int maxEnergy;

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
        energyText.text = maxEnergy.ToString() + "/" + maxEnergy.ToString();
    }

    private IEnumerator IncreaseDistance()
    {
        while(!player.IsDead)
        {
            yield return new WaitForSeconds(0.3f);
            _Distance++;
            distanceText.text = _Distance.ToString("00000" + "m");
        }
    }

    private void ApplyTextScaleEffect(Transform obj)
    {
        obj.transform.LeanScale(new Vector3(1.5f, 1.5f, 1.5f), 0.25f);
        obj.transform.LeanScale(new Vector3(1, 1, 1), 0.2f).setDelay(0.25f);
    }

    public void UpdateGold(int value)
    {
        _Gold += value;
        goldText.text = _Gold.ToString();
        ApplyTextScaleEffect(goldText.transform);
    }

    public void UpdateGem(int value)
    {
        _Gem += value;
        gemText.text = _Gem.ToString();
        ApplyTextScaleEffect(gemText.transform);
    }

    public void UpdateEnergy(int value)
    {
        _Energy += value;
        energyText.text = _Energy.ToString();
        ApplyTextScaleEffect(energyText.transform);
    }

    public int ApplyDamage(int value)
    {
        int newEnergy = Mathf.Clamp((_Energy - value), 0, 100);
        energyText.text = newEnergy.ToString() + "/" + maxEnergy.ToString();
        return _Energy = newEnergy;
    }

}
