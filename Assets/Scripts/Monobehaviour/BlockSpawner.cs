using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BlockSpawner : MonoBehaviour
{
    public Transform[] blocks;
    public float initialSpeed = 10;
    private float _spawnPos = -124;
    public float CurrentSpeed { get; set; }

    public void Init(float speed)
    {
        CurrentSpeed = speed;
        Awake();
    }

    private void Awake()
    {
        CurrentSpeed = initialSpeed;
    }

    public void SendNextBlock()
    {
        Transform obj = Instantiate(blocks[0], new Vector3(_spawnPos, 0, 0), Quaternion.identity, this.transform);
        obj.GetComponent<Block>().spawner = this;
    }

}
