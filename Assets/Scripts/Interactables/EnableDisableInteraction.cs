using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableInteraction : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public List<GameObject> toEnable;
    public List<GameObject> toDisable;

    public void Interact()
    {
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
