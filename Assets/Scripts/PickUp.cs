using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : InteractableObject
{
    // Start is called before the first frame update
    public Animator PlayerAnimator;
    public override void InteractWithObject()
    {
        base.InteractWithObject();
        PickUpItem();
    }

    private void PickUpItem()
    {
        Debug.Log("PickUpItem " + transform.name);
        
        Inventory.Instance.AddItem(this);
        PlayerAnimator.Play("PickUp");
        //Inventory.Instance.AddItem(transform.name);
        Destroy(gameObject);
    }
    
}
