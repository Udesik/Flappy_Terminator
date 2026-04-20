using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _jumpForce = 5f;
    
    private const KeyCode JumpKey = KeyCode.Space;

    private void OnEnable()
    {
        _inputReader.JumpRequested += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpRequested -= Jump;
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
    }
}
