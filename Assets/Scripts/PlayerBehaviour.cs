using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumps = 2;
    
    private Rigidbody2D rigidBody2D;
    private int remainingJumps;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            remainingJumps--;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
            remainingJumps = maxJumps;
    }
}