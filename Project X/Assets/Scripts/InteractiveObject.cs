using UnityEngine;

public enum ObjectType { Player, Enemy, Bullet }

public class InteractiveObject : MonoBehaviour
{
    public StatusManager Status { get; protected set; }
    public ObjectType Type { get => type; protected set => type = value; }
    [SerializeField] ObjectType type;

    protected virtual void Awake()
    {
        Status = new StatusManager(this);
    }
}