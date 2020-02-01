using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionWithCondition : InteractableObject
{
    public int itemsNeeded;
    public SceneSettings settings;
    public override void InteractWithObject()
    {
        base.InteractWithObject();
        if (Inventory.Instance.itemCount.Value >= itemsNeeded)
        {
            FireAllIInteractable();
            settings.playerAnimator.SetTrigger("PickUp");
        }
        else
        {
            settings.levelHint.SetActive(true);
            settings.levelHint.GetComponent<Animator>().SetTrigger("Disapear");
        }
    }

    private void FireAllIInteractable()
    {
        var scripts = gameObject.GetComponents<IInteractable>();
        Debug.Log(scripts.Length);
        foreach (var script in scripts)
        {
            script.Interact();
        }
    }
}
