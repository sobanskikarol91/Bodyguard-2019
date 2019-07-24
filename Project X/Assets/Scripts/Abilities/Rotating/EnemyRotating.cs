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

    private void OnEnable()
    {
        Debug.Log("Enable");
        if (ability)
        {
            ability.StopAllCoroutines();
            ability.StartCoroutine(Rotate());
        }
    }

    private void OnDisable()
    {
        if (ability) Debug.Log("Disable " + ability.gameObject.name);
        else Debug.Log("Disable without init");
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            Debug.Log("rotate: " + DirectionToPlayer + " " + ability.gameObject.name);
            ability.Rotate(DirectionToPlayer);
            yield return null;
        }
    }
}