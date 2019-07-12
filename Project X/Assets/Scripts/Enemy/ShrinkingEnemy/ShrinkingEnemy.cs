using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ShrinkingEnemy : MonoBehaviour
{
    [SerializeField] float timeToChangeState;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    //private IEnumerable ChangeState()
    //{
    //                private float leftTimeToChangeState;

    //yield return null;
    //}
}