using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public static Inventory Instance;

    [SerializeField] List<Item> items = new List<Item>();

    public struct Item
    {
        public string name;
        public Sprite sprite;
        public Item(string _name, Sprite _sprite)
        {
            name = _name;
            sprite = _sprite;
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Debug.LogWarning("Another Instance of Inventory!");
        }
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.X) && items.Count > 0)
        {
            Debug.Log(items[0].name);
            transform.GetComponent<SpriteRenderer>().sprite = items[0].sprite;
        }
    }

    public void AddItem(PickUp item)
    {
        items.Add(new Item(item.objectName, item.objectImage));
        Debug.Log("Added " + item.objectName);
    }

    public void RemoveItem(PickUp item)
    {
        items.Remove(items.Find(x => x.name == item.objectName));
    }

}
