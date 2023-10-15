using UnityEngine;

public class WeaponRotationMotor : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    private void Update()
    {
        var transform1 = transform;
        Vector2 direction = (PointerPosition - (Vector2)transform1.position).normalized;
        transform1.right = direction;

        Vector2 scale = transform1.localScale;
        scale.y = direction.x switch
        {
            < 0 => -1,
            > 0 => 1,
            _ => scale.y
        };

        transform.localScale = scale;
    }
}