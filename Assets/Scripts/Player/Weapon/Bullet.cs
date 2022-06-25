using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
        }

        DisableBullet(this.gameObject);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward / _speed);
    }

    private void DisableBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
