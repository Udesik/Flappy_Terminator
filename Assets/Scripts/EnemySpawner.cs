using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRangeY = 5;
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _defaultCapacity = 2;
    [SerializeField] private int _maxSize = 8;

	private float _spawnPositionX = 8.5f;

    private ObjectPool<Enemy> _pool;
    
    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => OnGetFromPool(enemy),
            actionOnRelease: (enemy) => OnReleaseFromPool(enemy),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: false,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
        );
    }
    
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_delay);
        
        while (true)
        {
            Fire();
            yield return wait;
        }
    }
    
    private void OnGetFromPool(Enemy enemy)
    {
        float y = Random.Range(-_spawnRangeY, _spawnRangeY);
        enemy.transform.position = new Vector3(_spawnPositionX, y, 0f);
        
        enemy.Health.Died += ReleaseEnemy;
        enemy.Health.ResetHealth();
        enemy.gameObject.SetActive(true);
    }

    private void OnReleaseFromPool(Enemy enemy)
    {
        enemy.Health.Died -= ReleaseEnemy;
        enemy.gameObject.SetActive(false);
    }

    private void ReleaseEnemy(GameObject enemyObject)
    {
        if (enemyObject.TryGetComponent(out Enemy enemy))
        {
            _pool.Release(enemy);
        }
    }

    private void Fire()
    {
        _pool.Get();
    }
}
