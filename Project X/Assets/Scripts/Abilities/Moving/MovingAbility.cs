using UnityEngine;

public class MovingAbility : MonoBehaviour
{
    [SerializeField] MoveType moveType;

    public MoveSettings Settings { get => settings; }
    [SerializeField] MoveSettings settings;

     
    private MoveType moveTypeInstance;

    private void Awake()
    {
        moveTypeInstance = Instantiate(moveType);
        moveTypeInstance.Init(this);
    }

    public void Update()
    {
        moveTypeInstance.Execute();
    }
}