using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    public void Move(float speed, Vector3 destination) // Called by Player Controller FixedUpdate
    {
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }

    public void Jump(Rigidbody rb, float fallMultiplier)
    {
        /*if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }*/
    }

    public void ApplyJump(Rigidbody rb, float jumpSpeed)
    {

    }

}
