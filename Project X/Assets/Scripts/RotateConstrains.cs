using UnityEngine;

public class RotateConstrains : MonoBehaviour 
{
    private Quaternion originRotation;

    private void Awake()
    {
        originRotation = transform.rotation;    
    }

    private void LateUpdate()
    {
        transform.rotation = originRotation;
    }
}