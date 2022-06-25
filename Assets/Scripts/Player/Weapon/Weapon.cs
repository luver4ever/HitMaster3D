using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ObjectPool
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private PlayerInput _input;

    private void Start()
    {
        Initialize();
    }

    public void Shoot()
    {
        if(TryGetObject(out Bullet bullet))
        {
            SetBullet(bullet.gameObject, _shootPoint);
        }
    }

    private void SetBullet(GameObject bullet, Transform spawnPosition)
    {
        bullet.SetActive(true);
        bullet.transform.position = spawnPosition.position;
        bullet.transform.rotation = spawnPosition.rotation;
        
    }    
}
