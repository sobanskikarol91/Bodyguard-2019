using UnityEngine;
using System.Linq;

public class ReflectingObjectsAbility : MonoBehaviour
{
    [SerializeField] ObjectType[] Reflectingtypes;

    private Collision2D collision;
    private readonly Vector3 reverseDirection = new Vector3(0, 0, 180);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.collision = collision;
        InteractiveObject interactive = collision.gameObject.GetComponent<InteractiveObject>();

        if (IsInteractive() && Reflectingtypes.Contains(interactive.Type))
            Reflect();
    }

    private void Reflect()
    {
        collision.transform.Rotate(reverseDirection);
    }

    private bool IsInteractive()
    {
        return collision.gameObject.GetComponent<InteractiveObject>();
    }
}