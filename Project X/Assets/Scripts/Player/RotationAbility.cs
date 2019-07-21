using UnityEngine;

public class RotationAbility : MonoBehaviour, ITwoAxisInput
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] TwoAxisInput input;
    public TwoAxisInput Input { get => input; set => input = value; }

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
        return Mathf.Atan2(input.Direction.y, input.Direction.x) * Mathf.Rad2Deg;
    }

    protected virtual void OnEnable()
    {
        ChooseState();
    }

    private void ChooseState()
    {
        if (speed == 0)
            input.Using += InstantRotation;
        else
            input.Using += SlerpRotate;
    }

    private void OnDisable()
    {
        input.Using -= SlerpRotate;
    }
}