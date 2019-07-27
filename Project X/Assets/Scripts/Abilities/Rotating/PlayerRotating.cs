using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRotation", menuName = "Rotating/Player")]
public class PlayerRotating : RotateType
{
    private PlayerInput input;
    private Transform transform;

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Init();
        input.Rotating.Using += Rotate;
        transform = ability.GetComponent<Transform>();
    }

    private void OnEnable()
    {
        if (input) input.Rotating.Using += Rotate;
    }

    private void OnDisable()
    {
        if (input) input.Rotating.Using -= Rotate;
    }

    void Rotate()
    {
        Vector2 direction = input.Rotating.Direction - (Vector2)transform.rotation.eulerAngles;
        ability.Rotate(direction);
    }
}