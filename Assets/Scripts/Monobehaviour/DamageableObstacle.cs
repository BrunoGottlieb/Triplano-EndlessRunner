using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableObstacle : MonoBehaviour, IObstacle
{
    public int TakeDamage()
    {
        return 2;
    }

}
