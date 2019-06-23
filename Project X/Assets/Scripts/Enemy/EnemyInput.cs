using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EnemyInput : MonoBehaviour, IDirectionInput
{
    private Player player;

    public Vector2 Direction { get { return (player.transform.position - transform.position).normalized; } }

    public event Action OnUse;

    private void Awake()
    {
        player = GameManager.instance.Player;
    }
}