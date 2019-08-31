using UnityEngine;

public class MovingAbility : Ability
{
    [SerializeField] MoveType moveType;

    public float Speed { get => speed; }
    [SerializeField] float speed = 10;

    public MoveType MoveTypeInstance { get; private set; }

    private void Start()
    {
        MoveTypeInstance = Instantiate(moveType);
        MoveTypeInstance.Init(this);
    }

    public void Update()
    {
        MoveTypeInstance.Execute();
    }
}