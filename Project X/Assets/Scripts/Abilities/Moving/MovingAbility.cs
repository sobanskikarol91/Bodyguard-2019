using UnityEngine;

public class MovingAbility : MonoBehaviour
{
    [SerializeField] MoveType moveType;

    public float Speed { get => speed; }
    [SerializeField] float speed = 10;


    private MoveType moveTypeInstance;

    private void Start()
    {
        Debug.Log(gameObject.name);
        moveTypeInstance = Instantiate(moveType);
        moveTypeInstance.Init(this);
    }

    public void Update()
    {
        moveTypeInstance.Execute();
    }
}