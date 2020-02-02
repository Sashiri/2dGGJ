using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnExit : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToDisable;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (objectToEnable) objectToEnable.SetActive(true);
        if (objectToDisable) objectToDisable.SetActive(false);
    }
}
