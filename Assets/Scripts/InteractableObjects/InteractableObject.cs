using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractableObject : MonoBehaviour
{
    public virtual void InteractWithObject()
    {
        Debug.Log("Interaction with object virtual " + transform.name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("Player"))
        {
            InteractWithObject();
        }
    }
}
