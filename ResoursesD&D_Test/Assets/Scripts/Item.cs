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

    public void UpdateData()
    {
        UpdateData(posInGrid, itemIdentifier);
    }

    public void UpdateData(Vector2Int posInGrid, ItemIdentifier itemIdentifier)
    { 
        this.posInGrid = posInGrid;
        this.itemIdentifier = itemIdentifier;
        transform.name = itemIdentifier.itemType.ToString();
        if (image == null) image = GetComponent<Image>();
        image.sprite = itemIdentifier.sprite;

        if (itemIdentifier.itemType == 0) {
            image.raycastTarget = false;
            image.color = new Color(1, 1, 1, 0);
        }else {
            image.raycastTarget = true;
            image.color = new Color(1, 1, 1, 1);
        }
    }

    public void ClearItem(Vector2Int cellPosInGrid, ItemIdentifier emptyII)
    {
        UpdateData(cellPosInGrid, emptyII);
    }
}
