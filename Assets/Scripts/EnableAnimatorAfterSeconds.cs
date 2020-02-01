using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimatorAfterSeconds : MonoBehaviour
{
    public Animator animatorToEnable;
    public float seconds;
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(seconds);
        animatorToEnable.enabled = true;
    }
}
