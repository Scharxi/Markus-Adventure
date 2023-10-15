using System;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1; // The experience points granted by defeating this enemy.

    public float triggerLength = 1; // The distance at which the enemy begins to chase the player.
    public float chaseLength = 5; // The maximum distance the enemy can chase the player.

    private bool chasing; // Indicates whether the enemy is currently chasing the player.
    private bool collidingWithPlayer; // Indicates if the enemy is colliding with the player.
    private Transform playerTransform; // Reference to the player's transform.
    private Vector3 startingPosition; // The enemy's starting position.

    private ContactFilter2D filter; // Filter for collision checks.
    private BoxCollider2D hitBox; // The enemy's hitbox collider.
    private Collider2D[] hits = new Collider2D[10]; // Array for storing colliders.

    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.Find("Markus").transform; // Find and reference the player's transform.
        startingPosition = transform.position; // Store the starting position of the enemy.
        hitBox = transform.GetChild(0).GetComponent<BoxCollider2D>(); // Get the hitbox collider from child objects.
    }

    private void FixedUpdate()
    {
        // Check if the player is in range to engage with the enemy.
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            // Check if the player is within the trigger range.
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
            {
                chasing = true;
            }

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    // Update the enemy's movement towards the player.
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
                else
                {
                    // If colliding with the player, stop chasing and move back to the starting position.
                    UpdateMotor(startingPosition - transform.position);
                }
            }
        }
        else
        {
            // If the player is out of chase range, move back to the starting position.
            UpdateMotor(startingPosition - transform.position);
            _animator.SetBool("isWalking", false); // Set the "isWalking" animation parameter to false.
            chasing = false;
        }

        // Check for collisions with the player.
        collidingWithPlayer = false;
        _collider2D.OverlapCollider(filter, hits);
        for (var i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            if (hits[i].CompareTag("Fighter") && hits[i].name == "Markus")
            {
                // Set collidingWithPlayer to true if colliding with the player.
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject); // Destroy the enemy object when it dies.
        // TODO: Enemy Death Animation 
        // TODO: Drop Loot 
        // TODO: Give Player Experience 
    }
}