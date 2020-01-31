using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    List<IInteractable> interactablesList;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (var interact in interactablesList)
            {
                interact.InteractWithObject();
            }
        }
    }
}
