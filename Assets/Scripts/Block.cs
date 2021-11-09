using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Block : MonoBehaviour
{
    public BlockSpawner spawner;
    private float _deathValue = 113;

    private void FixedUpdate()
    {
        this.transform.Translate(Vector3.right * spawner.CurrentSpeed * Time.deltaTime, Space.Self);

        if(this.transform.localPosition.x >= _deathValue)
        {
            spawner.SendNextBlock();
            Destroy(this.gameObject);
        }
    }
}
