using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BloodSpawner", menuName = "Effects/BloodSpawner")]
public class BloodSpawner : DeathEffect
{
    [SerializeField] GameObject[] blood;
    [SerializeField] GameObject particle;

    public override void CreateEffect(Transform transform)
    {
        GameObject prefab = ChooseRandom();
        GameObject instance = ObjectPoolManager.instance.Get(prefab);
        instance.transform.position = transform.position;
        SetRandomRotation(transform);
        SetFlip(transform);

        GameObject particleInstance = ObjectPoolManager.instance.Get(particle);
        particleInstance.transform.position = transform.position;
    }

    private void SetFlip(Transform transform)
    {
        
    }

    void SetRandomRotation(Transform transform)
    {

    }

    GameObject ChooseRandom()
    {
        int nr = UnityEngine.Random.Range(0, blood.Length);
        return blood[nr];
    }
}