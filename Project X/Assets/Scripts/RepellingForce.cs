
using UnityEngine;
using System.Linq;

public class RepellingForce : MonoBehaviour
{
    [SerializeField] float repellingForce = 1f;
    [SerializeField] private ObjectType[] repellingObjects;

    private Collider2D collision;

    private void OnTriggerStay2D(Collider2D collision)
    {
        this.collision = collision;
        if (ShouldRepelObject())
            RepelObject();
    }

    private bool ShouldRepelObject()
    {
        InteractiveObject InteractiveObject = collision.GetComponent<InteractiveObject>();
        if (!InteractiveObject) return false;

        return repellingObjects.Contains(InteractiveObject.Type);
    }


    private void RepelObject()
    {
        Vector3 force = (collision.transform.position - transform.position).normalized * repellingForce;
        collision.transform.position += force;
    }
}