using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collideable
{
    public int damagePoint = 1;
    public float knockBack = 2.0f;

    // Upgrades 
    public int weaponLevel = 0;

    private SpriteRenderer _renderer;

    // Swing 
    private float _coolDown = 0.5f;
    private float _lastSwing;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - _lastSwing > _coolDown)
            {
                _lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Fighter"))
        {
            if (collider.name == "Markus")
                return;

            var damage = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = knockBack,
            };

            collider.SendMessage("ReceiveDamage", damage);

            base.OnCollide(collider);
        }
    }


    private void Swing()
    {
        Debug.Log("Sword swong.");
    }
}