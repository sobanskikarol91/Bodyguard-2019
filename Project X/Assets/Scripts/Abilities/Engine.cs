using UnityEngine;


public class Engine : MonoBehaviour
{
    [SerializeField] MoveSettings moveSettings;
    [SerializeField] TwoAxisInput inputMovement;


    private void Awake()
    {
        inputMovement.InputUsing += Move;
    }

    public void Move()
    {
        transform.position += (Vector3)(moveSettings.Speed * inputMovement.Direction * Time.deltaTime);
    }
}