using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _capacity;

    private List<Bullet> _bullets = new List<Bullet>();

    public void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Bullet newBullet = Instantiate(_bulletPrefab, _container);
            newBullet.gameObject.SetActive(false);

            _bullets.Add(newBullet);
        }
    }

    public bool TryGetObject(out Bullet result)
    {
        result = _bullets.First(p => p.gameObject.activeSelf == false);

        return result != null;
    }

}
