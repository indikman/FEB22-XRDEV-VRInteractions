using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public Transform target;
    public Rigidbody follower;
   
    void FixedUpdate() // 0.02 seconds
    {
        follower.MovePosition(target.position);
    }

    private void Start()
    {
        ReleaseHandle();
    }

    public void ReleaseHandle()
    {
        target.position = transform.position;
        target.rotation = transform.rotation;
        follower.velocity = Vector3.zero;
        follower.angularVelocity = Vector3.zero;
    }
}
