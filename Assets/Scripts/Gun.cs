using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float shootForce;

    private GameObject tempBullet;

    public void Shoot()
    {
        tempBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        tempBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);
        Destroy(tempBullet, 5);

    }


}
