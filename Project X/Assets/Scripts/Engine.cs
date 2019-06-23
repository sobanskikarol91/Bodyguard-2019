using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Engine : MonoBehaviour
{
    [SerializeField] MoveSettings moveSettings;

    private IMoveInput input;

    private void Awake()
    {
        input = GetComponent<IMoveInput>();
        input.OnUse += Move;
    }

    public void Move()
    {
        transform.position += (Vector3)(moveSettings.Speed * input.Direction * Time.deltaTime);
    }
}