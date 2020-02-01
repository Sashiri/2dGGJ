using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public static Inventory Instance;

    [SerializeField] List<Item> items = new List<Item>();
    public Observer<int> itemCount = new Observer<int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Another Instance of Inventory!");
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        itemCount.Value = items.Count;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(items.Find(x => x.name == item.name));
        itemCount.Value = items.Count;
    }
}
