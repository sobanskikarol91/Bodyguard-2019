using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Character : MonoBehaviour
{
    private IInput movement;
    private Engine engine;


    protected  virtual void Awake()
    {
        movement = GetComponent<IInput>();
        engine = GetComponent<Engine>();
    }

    protected virtual void Update()
    {
        engine.Move();
    }
}