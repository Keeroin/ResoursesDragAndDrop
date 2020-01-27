using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Identifier", menuName = "Item Identifier")]
public class ItemIdentifier : ScriptableObject, IEquatable<ItemIdentifier>
{
    public Sprite sprite;
    public string itemType;
    public int typeIndex;
    public int level;

    public bool Equals(ItemIdentifier other)
    {
        if (other == null) return false;

        ItemIdentifier itemIndetifier = other as ItemIdentifier;
        if (itemIndetifier != null)
            return itemType.Equals(itemIndetifier.itemType) && level == itemIndetifier.level;
        else
            throw new ArgumentException("Object is not a Item Identifier");
    }
}
