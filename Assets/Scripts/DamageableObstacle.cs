using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableObstacle : MonoBehaviour, IObstacle
{
    public bool TakeDamage()
    {
        return false;
    }

}
