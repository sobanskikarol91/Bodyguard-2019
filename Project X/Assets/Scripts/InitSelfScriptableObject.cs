using UnityEngine;

public class InitSelfScriptableObject : ScriptableObject
{
    protected GameObject gameObject;

    public virtual void Init(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
}