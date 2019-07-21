using UnityEngine;


public class MovingAbility : MonoBehaviour, ITwoAxisInput
{
    [SerializeField] MoveSettings moveSettings;

    public TwoAxisInput Input { get => inputMovement; set => inputMovement = value; }

    [SerializeField] TwoAxisInput inputMovement;


    private void OnEnable()
    {
        inputMovement.Using += Move;
    }

    private void OnDisable()
    {
        inputMovement.Using -= Move;
    }

    public void Move()
    {
        transform.position += (Vector3)(moveSettings.Speed * inputMovement.Direction * Time.deltaTime);
    }
}