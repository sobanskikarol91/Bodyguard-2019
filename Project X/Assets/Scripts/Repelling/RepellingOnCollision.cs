using UnityEngine;

[RequireComponent(typeof(DoDamageOnCollision))]
[CreateAssetMenu(fileName = "RepellingOnCollision", menuName = "CollisionEffects/Repelling")]
public class RepellingOnCollision : CollisionEffect
{
    [SerializeField] float force = 0.1f;

    public override void OnCollision(Collision2D collision, Transform transform)
    {
        Debug.Log("aa");
        Vector3 direction = (Vector3)collision.contacts[0].point - transform.position;
        collision.transform.position += direction * force;
    }
}