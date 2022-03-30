using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    public GameObject paintPrefab;
    public Transform paintTip;
    public MeshRenderer paintTipColor;

    private GameObject tempPaint;
    private Material tempMaterial;

    public void StartPaint()
    {
        tempPaint = Instantiate(paintPrefab, paintTip.position, paintTip.rotation);
        tempPaint.transform.SetParent(paintTip);

        if(tempMaterial != null)
        {
            tempPaint.GetComponent<TrailRenderer>().material = tempMaterial;
        }
    }

    public void EndPaint()
    {
        if(tempPaint != null)
        {
            tempPaint.transform.SetParent(null);
            tempPaint = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("paint"))
        {
            tempMaterial = other.GetComponent<MeshRenderer>().material;
            paintTipColor.material = tempMaterial;
        }
    }

}
