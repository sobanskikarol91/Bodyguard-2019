using UnityEngine;

public class RotatingAbility : MonoBehaviour
{
    public float Speed { get => speed; }
    [SerializeField] protected float speed = 10;
    [SerializeField] RotateType type;
    private RotateType typeInstance;

    private void Start()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(this);
    }

    private void Update()
    {
        typeInstance.Execute();
    }
}