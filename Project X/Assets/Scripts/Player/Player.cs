using UnityEngine;

public class Player : Character
{
    [SerializeField] PlayerInput input;


    protected void Awake()
    {
        Type = ObjectType.Player;
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Init();
        GetComponent<ShootingAbility>().Input = input.Shooting;
        GetComponent<RotationAbility>().Input = input.Rotating;
    }

    private void Update()
    {
        input.Execute();
    }
}