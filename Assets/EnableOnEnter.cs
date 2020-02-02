using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnEnter : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToDisable;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectToEnable) objectToEnable.SetActive(true);
        if (objectToDisable) objectToDisable?.SetActive(false);
    }
}
