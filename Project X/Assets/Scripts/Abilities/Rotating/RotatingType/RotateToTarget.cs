using UnityEngine;

[CreateAssetMenu(fileName = "RotateToTarget", menuName = "Rotating/RotateToTarget")]
public class RotateToTarget : RotateType
{
    public enum RotateTo { Player, Target }

    [SerializeField] RotateTo rotateTarget;

    private Transform target;


    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        SetTarget();
    }

    private void SetTarget()
    {
        if (rotateTarget == RotateTo.Player)
            target = GameManager.instance.Player.transform;
    }

    public override void Execute()
    {
        Vector2 directionToPlayer = target.position - ability.transform.position;
        SetNewRotation(directionToPlayer);
    }

    public void SetRotateTarget(Transform target)
    {
        this.target = target;
    }
}