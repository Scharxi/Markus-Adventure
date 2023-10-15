using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Mover
{
    private Vector2 pointerInput, movementInput;

    // Property for public access to pointerInput
    public Vector2 PointerInput => pointerInput;

    private WeaponRotationMotor weaponRotation;

    // Unity attribute for field serialization in the editor
    [SerializeField] private InputActionReference movement, pointerPosition;

    private void Awake()
    {
        // Initialize the weaponRotation object with the first found WeaponRotationMotor in children
        weaponRotation = GetComponentInChildren<WeaponRotationMotor>();
    }

    private void FixedUpdate()
    {
        // Read input for movement and store it in movementInput
        movementInput = movement.action.ReadValue<Vector2>();
        // Update the player's movement using the inherited Mover object
        UpdateMotor(movementInput);
    }

    // Update is called once per frame
    void Update()
    {
        // Call the GetPointerInput method to update the pointer's position
        pointerInput = GetPointerInput();
        // Update the weapon target position (weaponRotation) based on pointerInput
        weaponRotation.PointerPosition = pointerInput;
    }

    // Method for converting mouse pointer position to world coordinates
    private Vector2 GetPointerInput()
    {
        // Read the mouse pointer position using the pointerPosition object
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        // Set the Z component of the mouse position to the near clip plane of the main camera
        mousePos.z = Camera.main!.nearClipPlane;
        // Convert screen coordinates to world coordinates and return them
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    // Overrides the AdjustSpriteDirection method from the base class Mover
    public override void AdjustSpriteDirection()
    {
        // Calculate the direction to the pointer and adjust the player sprite direction
        var direction = (weaponRotation.PointerPosition - (Vector2)transform.position).normalized;
        var scale = transform.localScale;
        if (direction.x > 0)
        {
            // Modify the X scale to correct the player sprite direction
            scale.x = 1; 
        }
        else if (direction.x < 0)
        {
            // Modify the X scale and invert the player sprite direction
            scale.x = -1; 
        }

        // Set the updated scale on the transform object
        transform.localScale = scale; 
    }
}