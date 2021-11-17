using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BlockSpawner : MonoBehaviour
{
    public Block[] blocks;
    public float initialSpeed = 10;
    private float _spawnPos = -124;
    public float CurrentSpeed { get; set; }
    public float SpawnPos { get { return _spawnPos; } }

    private static BlockSpawner _instance;
    public static BlockSpawner Instance { get { return _instance; } }

    public void Init(float speed)
    {
        CurrentSpeed = speed;
        Awake();
    }

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
        CurrentSpeed = initialSpeed;
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
