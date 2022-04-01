using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    public GameObject testObject;
    public float timeToFade;

   
    void Start()
    {
        StartCoroutine(Fader());
    }

    IEnumerator Fader()
    {
        yield return new WaitForSeconds(timeToFade);

        testObject.SetActive(false);

        yield return new WaitForSeconds(timeToFade);

        testObject.SetActive(true);
    }


}
