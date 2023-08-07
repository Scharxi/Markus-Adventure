using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    private Vector3 _moveDelta;


    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // Reset Move Delta 
        _moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _moveDelta = new(x, y, 0);

        // Swap sprite direction based on the direction the player is moving 
        if (_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        // Move the player
        transform.Translate(_moveDelta * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
}