using System;
using UnityEngine;

public class Collideable : MonoBehaviour
{
    public ContactFilter2D Filter;
    
    private BoxCollider2D _boxCollider2D;
    private Collider2D[] _hits;

    protected virtual void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _hits = new Collider2D[10];
    }

    protected virtual void Update()
    {
        _boxCollider2D.OverlapCollider(Filter, _hits);
        for (var i = 0; i < _hits.Length; i++)
        {
            if (_hits[i] == null)
            {
                continue;
            }

            OnCollide(_hits[i]);

            // clean up
            _hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D collider)
    {
        Debug.Log(collider.name);
    }
}