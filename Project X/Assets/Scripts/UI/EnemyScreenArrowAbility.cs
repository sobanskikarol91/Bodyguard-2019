using UnityEngine;

public class EnemyScreenArrowAbility : MonoBehaviour
{
    [SerializeField] EnemyScreenArrow arrow;

    private EnemyScreenArrow arrowInstance;


    private void OnEnable()
    {
        arrowInstance = ObjectPoolManager.instance.Get(arrow.gameObject).GetComponent<EnemyScreenArrow>();
        arrowInstance.AssignTo(transform);
        arrowInstance.ShowSprites();
    }

    private void OnDisable()
    {
        ObjectPoolManager.instance.ReturnToPool(arrowInstance.gameObject);
    }

    private void OnBecameVisible()
    {
        arrowInstance.HideSprites();
    }

    private void OnBecameInvisible()
    {
        arrowInstance.ShowSprites();
    }
}