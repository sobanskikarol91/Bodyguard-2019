using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "RotateToPlayer", menuName = "Rotating/RotateToPlayer")]
public class EnemyRotating : RotateType
{
    private Transform player;
    private Transform transform;
    private Vector2 DirectionToPlayer { get => player.position - transform.position; }

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        player = GameManager.instance.Player.transform;
        transform = ability.transform;
        this.ability = ability;
        ability.StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            ability.Rotate(DirectionToPlayer);
            yield return null;
        }
    }
}