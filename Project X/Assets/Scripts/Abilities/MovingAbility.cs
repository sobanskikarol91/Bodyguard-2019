using UnityEngine;


public class MovingAbility : MonoBehaviour
{
    [SerializeField] MoveSettings moveSettings;

    public MoveType MoveType { get => moveType; }
    [SerializeField] MoveType moveType;


    private void Awake()
    {
        moveType.Init(transform.transform, moveSettings);
    }

    public void Update()
    {
        moveType.Move();
    }
}