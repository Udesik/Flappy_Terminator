using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;
    
    public event UnityAction<int, int> Changed;
    public event UnityAction<GameObject> Died;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        Changed?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth == 0)
        {
            Died?.Invoke(gameObject);
        }
    }
    
    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

}
