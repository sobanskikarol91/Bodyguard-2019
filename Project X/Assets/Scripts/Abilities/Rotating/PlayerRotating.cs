using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRotation", menuName = "Rotating/Player")]
public class PlayerRotating : RotateType
{
    private PlayerInput input;

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Rotating.Using += Rotate;
    }

    private void OnEnable()
    {
        if (input && ability) input.Rotating.Using += Rotate;
    }

    private void OnDisable()
    {
        if (input && ability) input.Rotating.Using -= Rotate;
    }

    void Rotate()
    {
        ability.Rotate(input.Rotating.Direction);
    }
}