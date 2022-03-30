using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer tempRenderer = collision.transform.GetComponent<MeshRenderer>();

        if(tempRenderer != null)
        {
            tempRenderer.material.color = Random.ColorHSV();
        }
    }
}
