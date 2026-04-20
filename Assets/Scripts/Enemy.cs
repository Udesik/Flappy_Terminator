using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public EnemyShot Shot { get; private set; }

    private void OnValidate()
    {
        if (Health == null) 
            Health = GetComponent<Health>();
        
        if (Shot == null) 
            Shot = GetComponent<EnemyShot>();
    }
}
