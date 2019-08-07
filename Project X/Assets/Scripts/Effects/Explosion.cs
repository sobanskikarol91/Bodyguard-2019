using UnityEngine;

[CreateAssetMenu(fileName = "Explosion", menuName = "Effect/Explosion")]
public class Explosion : CollisionEffect
{
    [SerializeField] GameObject explosion;

    public override void OnCollision(Collision2D collision, Transform transform)
    {
        Debug.Log("Explosion");
        GameObject instance = ObjectPoolManager.instance.Get(explosion);
        instance.transform.position = collision.transform.position;
    }
}