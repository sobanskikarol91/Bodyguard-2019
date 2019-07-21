using UnityEngine;


public class Character : InteractiveObject
{
    [SerializeField] protected InputManager input;

    protected virtual void Awake()
    {
        input.Init();
    }

    private void Update()
    {
        input.Execute();
    }
}