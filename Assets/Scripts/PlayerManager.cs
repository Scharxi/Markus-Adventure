using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Fighter player;

    private void Awake()
    {
        instance = this;
    }
}