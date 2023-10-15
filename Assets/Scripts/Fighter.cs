using System.Security.Cryptography;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoints = 10; // Current hit points of the fighter.
    public int maxHitPoints = 10; // Maximum hit points the fighter can have.
    public float pushRecoverySpeed = 0.2f; // The speed at which the fighter recovers from being pushed.

    protected float immuneTime = 1.0f; // Duration of immunity after taking damage.
    protected float lastImmune; // Time when the fighter was last immune to damage.

    protected Vector3 pushDirection; // The direction the fighter is pushed when damaged.

    protected void ReceiveDamage(Damage damage)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            // Check if enough time has passed to end the fighter's immunity period.
            lastImmune = Time.time;
            hitPoints -= damage.damageAmount; // Reduce hit points by the damage amount.
            pushDirection = (transform.position - damage.origin).normalized * damage.pushForce;

            // TODO: Play Hit Animation (Placeholder comment for playing a hit animation).

            if (hitPoints <= 0)
            {
                hitPoints = 0;
                Death(); // Call the Death method when hit points reach zero.
            }
        }
    }

    protected virtual void Death()
    {
        // This method is intended to be overridden by derived classes to handle the fighter's death.
    }
}