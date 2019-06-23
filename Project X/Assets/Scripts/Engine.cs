using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Engine : MonoBehaviour
{
    [SerializeField] MoveSettings moveSettings;

    private IMoveInput input;


    public void Move()
    {
        transform.position += (Vector3)(moveSettings.Speed * input.Direction * Time.deltaTime);
    }

    private void Awake()
    {
        input = GetComponent<IMoveInput>();
    }
}