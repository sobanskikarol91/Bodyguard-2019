using UnityEngine;

public class MovingAbility : MonoBehaviour
{
    [SerializeField] MoveType moveType;

    private MoveType moveTypeInstance;

    private void Awake()
    {
        moveTypeInstance = Instantiate(moveType);
        moveTypeInstance.Init(this);
    }

    public void Update()
    {
        moveTypeInstance.Move();
    }
}