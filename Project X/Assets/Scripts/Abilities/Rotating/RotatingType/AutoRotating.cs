using UnityEngine;

[CreateAssetMenu(fileName = "AutoRotating", menuName = "Rotating/AutoRotating")]
public class AutoRotating : RotateType
{
    public override void Rotate()
    {
        float angle = ability.transform.rotation.eulerAngles.z + Time.deltaTime * speed;
        SetNewRotation(angle);
    }
}