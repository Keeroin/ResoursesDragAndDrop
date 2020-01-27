using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Item : MonoBehaviour, IEquatable<Item>
{
    public ItemIdentifier itemIdentifier;
    public Vector2Int posInGrid;

    Image image;

    public bool Equals(Item other)
    {
        return itemIdentifier.Equals(other.itemIdentifier);
    }

    public void UpdateData(Vector2Int posInGrid, ItemIdentifier itemIdentifier)
    {
        this.posInGrid = posInGrid;
        this.itemIdentifier = itemIdentifier;
        transform.name = itemIdentifier.itemType;
        if (image == null) image = GetComponent<Image>();
        image.sprite = itemIdentifier.sprite;
    }

    public void ClearItem(ItemIdentifier emptyII)
    {
        UpdateData(posInGrid, emptyII);
        image.color = new Color(0, 0, 0, 0);
    }
}
