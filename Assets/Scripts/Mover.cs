using System;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D _collider2D;
    protected Vector3 _moveDelta;
    protected RaycastHit2D _hit;

    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    protected Animator _animator; 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        _moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed);
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

        var isMoving = _moveDelta.sqrMagnitude > 0;
        _animator.SetBool("isWalking", isMoving);

        // Add push Vector, if any 
        _moveDelta += pushDirection;

        // reduce the push force every frame, based on the recovery speed 
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

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
            // transform.position = Vector3.MoveTowards(transform.position, _moveDelta, xSpeed * Time.deltaTime);
        }
    }
}