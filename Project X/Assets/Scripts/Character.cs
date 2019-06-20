using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Character : InteractiveObject
{
    private IMovementInput movement;
    private Engine engine;


    protected  virtual void Awake()
    {
        movement = GetComponent<IMovementInput>();
        engine = GetComponent<Engine>();
    }

    protected virtual void Update()
    {
        engine.Move();
    }
}