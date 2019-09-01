using UnityEngine;

[RequireComponent(typeof(HealthAbility))]
public class CreateObjectsAfterDeath : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int amount;

    private void Awake()
    {
        GetComponent<HealthAbility>().Death += SpawnObjects;
    }

    void SpawnObjects()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject instance =  ObjectPoolManager.instance.Get(prefab);
            instance.transform.position = transform.position;
        }
    }
}
