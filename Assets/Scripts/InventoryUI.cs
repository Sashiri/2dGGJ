using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI itemCountText;
    public GameObject inventorySpace;

    private void Start()
    {
        Inventory.Instance.itemCount.subscribers += UpdateItemsCount;
        UpdateItemsCount(Inventory.Instance.itemCount.Value);
    }

    private void UpdateItemsCount(int value)
    {
        if (value > 0)
        {
            itemCountText.text = value.ToString();
            inventorySpace.SetActive(true);
        }
        else
        {
            inventorySpace.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Inventory.Instance.itemCount.subscribers -= UpdateItemsCount;
    }
}
