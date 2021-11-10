using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObstacle : MonoBehaviour, IObstacle
{
    public bool TakeDamage()
    {
        return false;
    }

}
