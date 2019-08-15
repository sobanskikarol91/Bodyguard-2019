using UnityEngine;

public class EnemyScreenArrowAbility : MonoBehaviour
{
    [SerializeField] EnemyScreenArrow arrow;

    private EnemyScreenArrow arrowInstance;


    private void OnEnable()
    {
        arrowInstance = ObjectPoolManager.instance.Get(arrow.gameObject).GetComponent<EnemyScreenArrow>();
        arrowInstance.transform.SetParent(transform);
        arrowInstance.AssignTo(transform);
    }

    private void OnDisable()
    {
        ObjectPoolManager.instance.ReturnToPool(arrowInstance.gameObject);
    }

    private void OnBecameVisible()
    {
        arrowInstance.gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        arrowInstance.gameObject.SetActive(true);
    }
}