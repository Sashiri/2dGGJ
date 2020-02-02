using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;
    void Start()
    {
        offset = target.transform.position - gameObject.transform.position;
    }

    void Update()
    {
        gameObject.transform.position = target.transform.position - offset;
    }
}
