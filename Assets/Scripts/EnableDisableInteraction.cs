using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableInteraction : InteractableObject
{
    // Start is called before the first frame update
    public SceneSettings sceneSettings;
    public List<GameObject> toEnable;
    public List<GameObject> toDisable;
    public int neededItems = 3;

    public override void InteractWithObject()
    {
        base.InteractWithObject();
        if (Inventory.Instance.itemCount.Value >= neededItems)
        {
            PickUpItem();
        }
        else
        {
            sceneSettings.levelHint.SetActive(true);
        }
    }

    private void PickUpItem()
    {
        sceneSettings.playerAnimator.Play("PickUp");
        foreach (var enable in toEnable)
        {
            enable.SetActive(true);
        }
        foreach (var disable in toDisable)
        {
            disable.SetActive(false);
        }
    }

}
