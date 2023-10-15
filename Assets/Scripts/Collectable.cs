using UnityEngine;
using UnityEngine.InputSystem;

public class Collectable : Collideable
{
    protected bool _collected; // A flag to indicate if the collectable has been collected.
    [SerializeField] protected InputActionReference Interact; // A reference to an input action used for interaction.

    protected override void OnCollide(Collider2D collider)
    {
        // This method is called when a collision occurs with a 2D collider.
        if (collider.name == "Markus")
        {
            // Check if the collider's name is "Markus" to determine if it's the collecting entity.
            OnCollect(); // Trigger the collection behavior.
        }
    }

    protected virtual void OnCollect()
    {
        // This method is responsible for handling the collection behavior of the collectable.
        _collected = true; // Set the _collected flag to indicate that the collectable has been collected.
    }
}