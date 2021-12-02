using UnityEngine;

public sealed class Twerk : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f; //how fast it shakes
    [SerializeField] private float amount = 1.0f; //how much it shakes

    private void Update()
    {
        DoTwerkMove();
    }

    private void DoTwerkMove()
    {
        float x = Mathf.Sin(Time.time * speed) * amount;
        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, x);
    }

}
