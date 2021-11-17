using UnityEngine;
using UnityEngine.UI;

public sealed class BlockSpawner : MonoBehaviour
{
    public Block[] blocks;
    public float initialSpeed = 10;
    private float _spawnPos = -124;
    [SerializeField] private int _easyMediumDistance;
    [SerializeField] private int _mediumDistance;
    [SerializeField] private int _mediumHardDistance;
    [SerializeField] private int _hardDistance;
    [SerializeField] private Button touchToStartBtn;
    [SerializeField] private PlayerAnimationManager playerAnimation;

    public float CurrentSpeed { get; set; }
    public float SpawnPos { get { return _spawnPos; } }
    public int EasyMediumDistance { get { return _easyMediumDistance; } }
    public int MediumDistance { get { return _mediumDistance; } }
    public int MediumHardDistance { get { return _mediumHardDistance; } }
    public int HardDistance { get { return _hardDistance; } }

    private static BlockSpawner _instance;
    public static BlockSpawner Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError("Not supposed to have more than 1 BlockSpawner on scene");
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        touchToStartBtn.onClick.AddListener(TouchToStart);
    }

    public void TouchToStart()
    {
        CurrentSpeed = initialSpeed; // move the scenary
        touchToStartBtn.gameObject.SetActive(false); // hide the 'touch to start' screen
        playerAnimation.StartRunning(); // start player run animation
        StatsSystem.Instance.StartMeasuringDistance(); // start measuring the distance
    }

    public void StopAllBlocks()
    {
        foreach(Block block in blocks)
        {
            block.IsEnabled = false;
        }
    }

    /*private IEnumerator IncreaseSpeed(float interval, float increment)
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            CurrentSpeed += increment;
        }
    }*/

    /*public void SendNextBlock()
    {
        Transform obj = Instantiate(blocks[0], new Vector3(_spawnPos, 0, 0), Quaternion.identity, this.transform);
        obj.GetComponent<Block>().spawner = this;
    }*/

}
