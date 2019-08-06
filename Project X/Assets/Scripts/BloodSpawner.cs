using UnityEngine;

[CreateAssetMenu(fileName = "BloodSpawner", menuName = "Effects/BloodSpawner")]
public class BloodSpawner : DeathEffect
{
    [SerializeField] GameObject[] blood;

    public override void CreateEffect(Transform transform)
    {
        GameObject prefab = ChooseRandom();
        GameObject instance = ObjectPoolManager.instance.Get(prefab);
        instance.transform.position = transform.position;
    }

    GameObject ChooseRandom()
    {
        int nr = Random.Range(0, blood.Length);
        return blood[nr];
    }
}