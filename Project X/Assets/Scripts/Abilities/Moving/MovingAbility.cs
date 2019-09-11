using UnityEngine;

public class MovingAbility : Ability
{
    public float Speed { get => speed; set => speed = value; }
    [SerializeField] float speed = 10;

    public MoveType MoveTypeInstance { get; private set; }
    [SerializeField] MoveType moveType;

    public float OriginSpeed { get; private set; }

    private void Start()
    {
        OriginSpeed = speed;
        MoveTypeInstance = Instantiate(moveType);
        MoveTypeInstance.Init(this);
    }

    public void Update()
    {
        MoveTypeInstance.Execute();
    }

    private void OnEnable()
    {
        speed = OriginSpeed;
    }
}