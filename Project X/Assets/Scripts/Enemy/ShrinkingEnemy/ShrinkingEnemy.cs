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
        StartCoroutine(ChangeState());
    }

    private void OnDisable()
    {

    }

    private IEnumerator ChangeState()
    {
        while (true)
        {
            yield return StartCoroutine(ShrinkState());
        }
    }

    IEnumerator ShrinkState()
    {
        float leftTimeToChangeState = timeToChangeState;
        float percantage = 0;
        float timeStart = Time.time;

        while (leftTimeToChangeState > 0)
        {
            leftTimeToChangeState -= Time.deltaTime;
            percantage = (Time.time - timeStart) / timeToChangeState;
        }

        yield return null;
    }
}