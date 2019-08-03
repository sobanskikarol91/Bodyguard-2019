using UnityEngine;

public  class ReturnToPool : MonoBehaviour
{
    public int Id;

    protected void ReturnObjectToPool()
    {
        ObjectPoolManager.instance.ReturnToPool(this);
    }
}