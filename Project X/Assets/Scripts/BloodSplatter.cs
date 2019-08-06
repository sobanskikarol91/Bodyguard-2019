using UnityEngine;

[CreateAssetMenu(fileName = "BloodSplatter", menuName = "Effects/BloodSplatter")]
public class BloodSplatter : DeathEffect
{
    [SerializeField] GameObject[] blood;
    [SerializeField] GameObject particle;

    public override void CreateEffect(Transform transform)
    {
        GameObject prefab = ChooseRandom();
        Transform instance = ObjectPoolManager.instance.Get(prefab).transform;
        instance.position = transform.position;
        SetRandomRotation(instance);
        SetFlip(transform);

        GameObject particleInstance = ObjectPoolManager.instance.Get(particle);
        particleInstance.transform.position = transform.position;
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

    GameObject ChooseRandom()
    {
        int nr = Random.Range(0, blood.Length);
        return blood[nr];
    }
}