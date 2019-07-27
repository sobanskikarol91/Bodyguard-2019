using UnityEngine;

public enum ObjectType { Player, Enemy, Bullet }

public class InteractiveObject : MonoBehaviour
{
    public ObjectType Type { get => type; protected set => type = value; }
    [SerializeField] ObjectType type;
}