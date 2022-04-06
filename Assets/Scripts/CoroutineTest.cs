using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    public GameObject testObject;
    public float timeToFade;

    public Transform startPoint;
    public Transform endPoint;

    [Range(0,1)]
    public float lerpValue = 0; // This is gonna be a value 0-1
   
    void Start()
    {
        
    }

    private void Update()
    {
        testObject.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, lerpValue);
    }


}
