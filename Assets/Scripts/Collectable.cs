using UnityEngine;

public class Collectable : Collideable
{
    protected bool _collected;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Markus")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        _collected = true;
    }
}