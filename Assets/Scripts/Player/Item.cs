using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute()]
public class Item : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public Item(string _name, Sprite _sprite)
    {
        name = _name;
        sprite = _sprite;
    }
}