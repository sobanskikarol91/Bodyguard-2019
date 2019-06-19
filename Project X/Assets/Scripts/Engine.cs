using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Engine : MonoBehaviour, IMovement
{
    private IMovementInput input;
    [SerializeField] MoveSettings moveSettings;

    public void Move()
    {
        transform.position += (Vector3)(moveSettings.Speed * input.Movement * Time.deltaTime);
    }

    private void Awake()
    {
        input = GetComponent<IMovementInput>();
    }
}