using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twerk : MonoBehaviour
{
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes

    private void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * amount;
        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, x);
    }
}
