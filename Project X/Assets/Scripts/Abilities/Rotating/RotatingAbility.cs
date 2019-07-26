using System;
using UnityEngine;

public class RotatingAbility : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] RotateType type;

    private RotateType typeInstance;
    private Action choosenAlgorithm = delegate { };
    private Vector2 origin, destination;


    public void Rotate(Vector2 destination)
    {
        this.destination = destination;
        choosenAlgorithm();
    }

    protected void SlerpRotate()
    {
        float angle = GetAngle();
        Quaternion rotation = Quaternion.AngleAxis(angle, transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    protected void InstantRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, GetAngle());
    }

    private float GetAngle()
    {
        return Mathf.Atan2(destination.y, destination.x) * Mathf.Rad2Deg;
    }

    private void ChooseAlgorithm()
    {
        choosenAlgorithm = speed == 0 ? (Action)InstantRotation : SlerpRotate;
    }

    private void OnEnable()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(this);
        ChooseAlgorithm();
    }
}