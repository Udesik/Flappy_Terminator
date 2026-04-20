using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletShooter _shot;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _defaultCapacity = 20;
    [SerializeField] private int _maxSize = 50;

    private ObjectPool<Bullet> _pool;
    
    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
            createFunc: () => Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation),
            actionOnGet: (bullet) => OnGetFromPool(bullet),
            actionOnRelease: (bullet) => OnReleaseFromPool(bullet),
            actionOnDestroy: (bullet) => Destroy(bullet.gameObject),
            collectionCheck: false,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
        );
    }

    private void OnEnable()
    {
        _shot.FiredBullet += Fire;
    }

    private void OnDisable()
    {
        _shot.FiredBullet -= Fire;
    }
    
    private void OnGetFromPool(Bullet bullet)
    {
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.rotation = _spawnPoint.rotation;

        bullet.Died += ReleaseBullet;
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseFromPool(Bullet bullet)
    {
        bullet.Died -= ReleaseBullet;
        bullet.gameObject.SetActive(false);
    }

    private void ReleaseBullet(Bullet bullet)
    {
        _pool.Release(bullet);
    }

    private void Fire()
    {
        _pool.Get();
    }
}
