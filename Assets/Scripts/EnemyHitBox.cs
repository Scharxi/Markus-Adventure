using UnityEngine;
using UnityEngine.Serialization;

public class EnemyHitBox : Collideable
{
    public int damageAmount = 1;
    public float pushForce = 2;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Fighter") && collider.name == "Markus")
        {
            // Create a new damage object, before sending it to the player 
            var damage = new Damage
            {
                damageAmount = damageAmount,
                origin = transform.position,
                pushForce = pushForce
            };

            collider.SendMessage("ReceiveDamage", damage);
        }
    }
}