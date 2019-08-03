using UnityEngine;

public  class ReturnToPool : MonoBehaviour
{
    public int Id;

    protected void ReturnObjectToPool()
    {
        Debug.Log("Return object to pool on collision: " + gameObject.name);
        ObjectPoolManager.instance.ReturnToPool(this);
    }
}