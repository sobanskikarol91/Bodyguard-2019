using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Character : InteractiveObject
{
    private Engine engine;
    
    protected  virtual void Awake()
    {
        engine = GetComponent<Engine>();
    }
}