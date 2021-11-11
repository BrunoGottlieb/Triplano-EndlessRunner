using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Block : MonoBehaviour
{
    public BlockSpawner spawner;
    [SerializeField] private GameObject[] contentGroup;
    private float _deathValue = 110.3f;

    public bool IsEnabled { get; set; }

    private void OnEnable()
    {
        IsEnabled = true;
        ChooseContent();
    }

    private void ChooseContent() // random choose a group of obstacles and collectables
    {
        if(contentGroup.Length > 0)
        {
            foreach (GameObject content in contentGroup)
            {
                content.gameObject.SetActive(false);
            }
            contentGroup[Random.Range(0, contentGroup.Length)].SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if(IsEnabled) // if player is alive, keep moving the block
        {
            this.transform.Translate(Vector3.right * spawner.CurrentSpeed * Time.deltaTime, Space.Self);

            if (this.transform.localPosition.x >= _deathValue)
            {
                //spawner.SendNextBlock();
                this.transform.localPosition = new Vector3(spawner.SpawnPos, 0, 0);
                ChooseContent();
            }
        }
    }
}
