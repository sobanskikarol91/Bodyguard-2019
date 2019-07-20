using UnityEngine;

public abstract class Rotation : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    protected abstract Vector2 Direction { get; }

    protected TwoAxisInput input;

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
        return Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
    }

    protected virtual void OnEnable()
    {
        ChooseState();
    }

    private void ChooseState()
    {
        if (speed == 0)
            input.InputUsing += InstantRotation;
        else
            input.InputUsing += SlerpRotate;
    }

    private void OnDisable()
    {
        input.InputUsing -= SlerpRotate;
    }
}
