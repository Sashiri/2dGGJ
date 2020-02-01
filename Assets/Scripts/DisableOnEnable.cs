using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        enabled = false;
        gameObject.SetActive(false);
    }
}
