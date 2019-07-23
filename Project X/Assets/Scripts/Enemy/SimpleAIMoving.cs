using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Simple", menuName = "")]
public class SimpleAIMoving : MoveType
{
    [SerializeField] MoveSettings moveSettings;
    [SerializeField] Transform transform;

    private Player player;

    private void Awake()
    {
        player = GameManager.instance.Player;
    }

    public override void Move()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position += (Vector3)(moveSettings.Speed * direction * Time.deltaTime);
    }
}