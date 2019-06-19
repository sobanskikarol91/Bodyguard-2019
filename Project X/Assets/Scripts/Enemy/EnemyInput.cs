using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyInput : MonoBehaviour, IMovementInput
{
    [SerializeField] Player player;
    public Vector2 Movement { get { return (player.transform.position - transform.position).normalized; } }
}