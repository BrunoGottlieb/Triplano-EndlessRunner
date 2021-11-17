using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Block : MonoBehaviour
{
    public BlockSpawner spawner;
    [SerializeField] private GameObject debugStage;
    [SerializeField] private GameObject[] _easyGroup;
    [SerializeField] private GameObject[] _mediumGroup;
    [SerializeField] private GameObject[] _hardGroup;
    private float _deathValue = 110.3f;

    public bool IsEnabled { get; set; }
    private GameObject _CurrentStage { get; set; }

    private void OnEnable()
    {
        IsEnabled = true;
        ChooseContent();
    }

    private void ChooseContent() // random choose a group of obstacles and collectables
    {
        int distance = StatsSystem.Instance != null? StatsSystem.Instance.Distance : 0; // current distance travelled by player
        _CurrentStage?.SetActive(false); // disable (now)previous stage

        if (distance < spawner.EasyMediumDistance) // will spawn an easy stage
        {
            _CurrentStage = GetRandomStage(_easyGroup);
        }
        else if (distance >= spawner.EasyMediumDistance && distance < spawner.MediumDistance) // will easy stages and medium stages
        {
            _CurrentStage = GetRandomStage(_easyGroup, _mediumGroup);
        }
        else if(distance >= spawner.MediumDistance && distance < spawner.MediumHardDistance) // will spawn a medium stage
        {
            _CurrentStage = GetRandomStage(_mediumGroup);
        }
        else if (distance >= spawner.MediumDistance && distance < spawner.HardDistance) // will spawn medium stages and hard stages
        {
            _CurrentStage = GetRandomStage(_mediumGroup, _hardGroup);
        }
        else if(distance >= spawner.HardDistance) // will spawn only hard stages
        {
            _CurrentStage = GetRandomStage(_hardGroup);
        }
        else
        {
            Debug.LogError("Something went wrong on block difficult chooser");
        }

        if(debugStage != null) // only for tests porpouse
        {
            _CurrentStage = debugStage;
        }

        _CurrentStage.SetActive(true);
    }

    private GameObject GetRandomStage(GameObject[] groupA, GameObject[] groupB = null)
    {
        int sizeA = groupA.Length;
        int sizeB = groupB != null ? groupB.Length : 0;
        int rand = Random.Range(0, sizeA + sizeB);
        
        if(groupA.Length > rand)
        {
            return groupA[rand];
        }
        else
        {
            return groupB[rand - sizeA];
        }

    }

    private void FixedUpdate()
    {
        if(IsEnabled) // if player is alive, keep moving the block
        {
            this.transform.Translate(Vector3.right * spawner.CurrentSpeed * Time.deltaTime, Space.Self);

            if (this.transform.localPosition.x >= _deathValue)
            {
                this.transform.localPosition = new Vector3(spawner.SpawnPos, 0, 0);
                ChooseContent();
            }
        }
    }
}
