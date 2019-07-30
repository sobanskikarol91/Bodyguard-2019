using UnityEngine;

public class RotatingAbility : MonoBehaviour
{
    [SerializeField] RotateType type;
    private RotateType typeInstance;


    private void Awake()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(this);
    }

    private void Update()
    {
        typeInstance.Execute();
    }
}