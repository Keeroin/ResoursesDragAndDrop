using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Identifier", menuName = "Item Identifier")]
public class ItemIdentifier : ScriptableObject, IEquatable<ItemIdentifier>
{
    public Sprite sprite;
    public ItemTypes itemType;
    public int level;

    public bool Equals(ItemIdentifier other)
    {
        if (other == null) return false;

        ItemIdentifier itemIndetifier = other as ItemIdentifier;
        if (itemIndetifier != null)
            return itemType == other.itemType && level == itemIndetifier.level;
        else
            throw new ArgumentException("Object is not a Item Identifier");
    }
}

public enum ItemTypes : byte
{
    Empty = 0,
    Wood,
    Iron,
    Gold
}
