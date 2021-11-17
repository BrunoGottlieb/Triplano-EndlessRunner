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

    public int Gold { get; set; }
    public int Gem { get; set; }
    public int Energy { get; set; }
    public int Distance { get; set; }
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
        energyText.text = maxEnergy.ToString() + "/" + maxEnergy.ToString();
    }

    public void StartMeasuringDistance()
    {
        StartCoroutine(IncreaseDistance());
    }

    private IEnumerator IncreaseDistance()
    {
        while(!player.IsDead)
        {
            yield return new WaitForSeconds(0.3f);
            Distance++;
            distanceText.text = Distance.ToString("00000" + "m");
        }
    }

    private void ApplyTextScaleEffect(Transform obj)
    {
        obj.transform.LeanScale(new Vector3(1.5f, 1.5f, 1.5f), 0.25f);
        obj.transform.LeanScale(new Vector3(1, 1, 1), 0.2f).setDelay(0.25f);
    }

    public void UpdateGold(int value)
    {
        Gold += value;
        goldText.text = Gold.ToString();
        ApplyTextScaleEffect(goldText.transform);
    }

    public void UpdateGem(int value)
    {
        Gem += value;
        gemText.text = Gem.ToString();
        ApplyTextScaleEffect(gemText.transform);
    }

    public void UpdateEnergy(int value)
    {
        Energy += value;
        energyText.text = Energy.ToString();
        ApplyTextScaleEffect(energyText.transform);
    }

    public int ApplyDamage(int value)
    {
        int newEnergy = Mathf.Clamp((Energy - value), 0, 100);
        energyText.text = newEnergy.ToString() + "/" + maxEnergy.ToString();
        return Energy = newEnergy;
    }

}
