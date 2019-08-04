using UnityEngine;

public class EnemyScreenArrowAbility : MonoBehaviour
{
    [SerializeField] EnemyScreenArrow arrow;

    private EnemyScreenArrow arrowInstance;

    private void OnEnable()
    {
        arrowInstance = ObjectPoolManager.instance.Get(arrow.gameObject).GetComponent<EnemyScreenArrow>();
        arrowInstance.SetTarget(transform);
    }

    private void OnDisable()
    {
        ObjectPoolManager.instance.ReturnToPool(arrowInstance.gameObject);
    }
    //onbecamebisible
}