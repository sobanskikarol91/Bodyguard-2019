using UnityEngine;


public class Engine : MonoBehaviour
{
    [SerializeField] MoveSettings moveSettings;
    TwoAxisInput inputMovement;


    private void Start()
    {
        inputMovement = GameManager.instance.Input.Movement;
        inputMovement.InputUsing += Move;
    }

    public void Move()
    {
        transform.position += (Vector3)(moveSettings.Speed * inputMovement.Direction * Time.deltaTime);
    }
}