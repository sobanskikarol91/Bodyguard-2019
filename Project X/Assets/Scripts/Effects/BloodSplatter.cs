using System.Collections.Generic;
using UnityEngine;


public class BloodSplatter : MonoBehaviour
{
    [SerializeField] GameObject[] blood;

    private ParticleSystem particle;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject prefab = ChooseRandom();
        Transform instance = ObjectPoolManager.instance.Get(prefab).transform;
        int numCollisionEvents = particle.GetCollisionEvents(other, collisionEvents);

        Vector3 position = collisionEvents[0].intersection;
        instance.position = position;
        SetRandomRotation(instance);
        SetFlip(transform);
    }

    GameObject ChooseRandom()
    {
        int nr = Random.Range(0, blood.Length);
        return blood[nr];
    }

    private void SetFlip(Transform transform)
    {
        bool shouldFlip = (Random.value > .5f);

        if (shouldFlip)
            transform.localScale *= -1f;
    }

    void SetRandomRotation(Transform transform)
    {
        float angle = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, 0, angle));
    }
}