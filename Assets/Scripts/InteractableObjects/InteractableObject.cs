using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public string objectName;
    public Sprite objectImage;

    public virtual void InteractWithObject()
    {
        Debug.Log("Interaction with object virtual " + transform.name);
    }

    public virtual void SetItem()
    {
        transform.name = objectName;
        spriteRenderer.sprite = objectImage;
    }

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetItem();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("Player"))
        {
            InteractWithObject();
        }
    }


}
