using UnityEngine;

public class MovingAbility : Ability
{
    public float Speed { get => speed; set => speed = value; }
    [SerializeField] float speed = 10;

    public MoveType MoveTypeInstance { get; private set; }
    [SerializeField] MoveType moveType;


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