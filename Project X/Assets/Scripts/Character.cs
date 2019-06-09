using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Character : MonoBehaviour
{
    private IInput movement;
    private Engine engine;


    private void Awake()
    {
        movement = GetComponent<IInput>();
        engine = GetComponent<Engine>();
    }

    private void Update()
    {
        engine.Move();
    }
}