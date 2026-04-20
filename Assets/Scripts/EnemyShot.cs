using System.Collections;
using UnityEngine;

public class EnemyShot : BulletShooter
{
    [SerializeField] private float _delay = 1f;
    private Coroutine _spawnRoutine;

    private void OnEnable()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_delay);
        while (true)
        {
            NotifyFire();
            yield return wait;
        }
    }
}