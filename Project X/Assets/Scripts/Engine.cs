using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Engine : MonoBehaviour
{
    private IInput input;
    private new Transform transform;
    [SerializeField] CharacterSettings settings;


    private void Awake()
    {
        input = GetComponent<IInput>();
        transform = GetComponent<Transform>();
    }

    public virtual void Move()
    {
        transform.position += (Vector3)(settings.Speed * input.Movement* Time.deltaTime);
    }
}