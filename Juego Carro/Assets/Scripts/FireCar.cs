using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCar : MonoBehaviour
{    
    public Transform bulletPrefab; 
    public Transform bulletSpawnPoint;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }
    private void Shoot()
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
}
