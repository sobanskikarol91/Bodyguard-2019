using UnityEngine;

[CreateAssetMenu(fileName = "LessAccuracy", menuName = "Shooting/Effects/LessAccuracy")]
public class LessAccuracyShooting : ShootingEffect
{
    [SerializeField] float rotationOffset = 3f;
    [SerializeField] float positionOffset = 0.1f;

    public override void OnShoot(Transform bullet)
    {
        ModifyRotation(bullet);
        ModifyPosition(bullet);
    }

    private void ModifyPosition(Transform bullet)
    {
        float position = Random.Range(-positionOffset, positionOffset);
        bullet.localPosition += new Vector3(position, position);
    }

    private void ModifyRotation(Transform bullet)
    {
        float rotation = Random.Range(-rotationOffset, rotationOffset);
        bullet.Rotate(new Vector3(0, 0, rotation));
    }
}