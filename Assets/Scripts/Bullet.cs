using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 20f;
	[SerializeField] private int _deathRange = 20;

    public event UnityAction<Bullet> Died;
    
    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if (Mathf.Abs(transform.position[0]) > _deathRange || Mathf.Abs(transform.position[1]) > _deathRange)
        {
            Died?.Invoke(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health enemy = collision.gameObject.GetComponent<Health>();

        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }
        
        Died?.Invoke(this);
    }
}
