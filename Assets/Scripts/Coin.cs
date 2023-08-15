using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Coin : Collectable
{
    public int Value = 10;

    protected override void OnCollect()
    {
        _collected = true;
        Destroy(gameObject);
        GameManager.instance.Coins += Value;
    }
}