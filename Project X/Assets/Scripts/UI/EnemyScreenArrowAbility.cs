using UnityEngine;

public class EnemyScreenArrowAbility : MonoBehaviour
{
    [SerializeField] EnemyScreenArrow arrow;

    private EnemyScreenArrow arrowInstance;


    private void OnEnable()
    {
        arrowInstance = ObjectPoolManager.instance.Get(arrow.gameObject).GetComponent<EnemyScreenArrow>();
        arrowInstance.gameObject.SetActive(false);
        arrowInstance.AssignTo(transform);
    }

    private void OnDisable()
    {
        ObjectPoolManager.instance.ReturnToPool(arrowInstance.gameObject);
    }

    private void OnBecameVisible()
    {
        arrowInstance.gameObject.SetActive(true);
        //arrowInstance.HideSprites();
    }

    private void OnBecameInvisible()
    {
        arrowInstance.gameObject.SetActive(false);
        //arrowInstance.ShowSprites();
    }
}