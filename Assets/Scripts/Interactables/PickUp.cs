using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public Item item;
    public void Interact()
    {
        Debug.Log("PickUpItem " + transform.name);
        Inventory.Instance.AddItem(item);
        Destroy(gameObject);
    }
}
