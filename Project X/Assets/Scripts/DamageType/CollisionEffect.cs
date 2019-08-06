using UnityEngine;

public abstract class CollisionEffect : ScriptableObject
{
    public abstract void OnCollision(Collision2D collision, Transform transform);
}