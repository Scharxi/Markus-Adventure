using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    private Vector3 _moveDelta;
    private RaycastHit2D _hit;


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

        _moveDelta = new Vector3(x, y, 0);
        _moveDelta.Normalize();

        // Swap sprite direction based on the direction the player is moving 
        if (_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // make sure we can move in this direction, by casting a box there first, if the box returns null, we can move
        _hit = Physics2D.BoxCast(transform.position, _collider2D.size, 0, new Vector2(0, _moveDelta.y),
            MathF.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));

        // check if the player collides with something 
        if (!_hit)
        {
            // Move the player
            transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);
        }

        // make sure we can move in this direction, by casting a box there first, if the box returns null, we can move
        _hit = Physics2D.BoxCast(transform.position, _collider2D.size, 0, new Vector2(_moveDelta.x, 0),
            MathF.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));

        // check if the player collides with something 
        if (!_hit)
        {
            // Move the player
            transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}