using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer;

    public void InteractWithObject()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        spriteRenderer.enabled = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            InteractWithObject();
        }
    }
}
