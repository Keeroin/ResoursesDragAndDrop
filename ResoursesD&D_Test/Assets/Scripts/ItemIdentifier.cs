using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item Identifier", menuName = "Item Identifier")]
public class ItemIdentifier : ScriptableObject, IComparable
{
    public Sprite sprite;
    public string itemType;

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        ItemIdentifier itemIndetifier = obj as ItemIdentifier;
        if (itemIndetifier != null)
            return this.itemType.CompareTo(itemIndetifier.itemType);
        else
            throw new ArgumentException("Object is not a Item Identifier");
    }
}
