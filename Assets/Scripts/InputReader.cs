using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;
    
    public event Action JumpRequested;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            JumpRequested?.Invoke();
    }
}
