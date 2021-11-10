using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObstacle : MonoBehaviour, IObstacle
{
    public int TakeDamage()
    {
        return 1;
    }

}
