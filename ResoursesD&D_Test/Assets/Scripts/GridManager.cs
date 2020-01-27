using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PopulateGrid))]
public class GridManager : MonoBehaviour
{
    public ItemsSelectionList itemsSelectionList = new ItemsSelectionList();
    public Vector3 halfCellSize => gridComp.cellSize * .5f * Vector2.one;

    PopulateGrid gridComp;
    Item[,] gridArray = new Item[5, 5];
    const int maxLevel = 2;

    void Start()
    {
        gridComp = GetComponent<PopulateGrid>();
    }

    public void SetItemInArray(Vector2Int posInGrid, Item item)
    {
        gridArray[posInGrid.x, posInGrid.y] = item;
    }

    public bool IsItemInGridSpace(Vector2 position)
    {
        return position.x < gridComp.endPoint.x && position.y < gridComp.endPoint.y
            && position.x >= 0f                  && position.y >= 0f;
    }

    public bool IsItemEmpty(Vector3 localPos)
    {
        return IsItemEmpty(GetItemFromLocalPos(localPos));
    }

    public bool IsItemEmpty(Item item)
    {
        return item.itemIdentifier.typeIndex == 0;
    }

    public bool IsItemsAreEqual(Item item, Vector3 otherItemPos)
    {
        Item otherItem = GetItemFromLocalPos(otherItemPos);
        return item.Equals(otherItem);
    }

    public Vector2Int GetGridPosFromItemLocalPos(Vector3 itemLocalPos)
    {
        return new Vector2Int((int)itemLocalPos.x / gridComp.cellSize, (int)itemLocalPos.y / gridComp.cellSize);
    }

    public Vector3 GetItemLocalPositionInGrid(Item item)
    {
        return GetItemLocalPositionInGrid(item.posInGrid);
    }

    public Vector3 GetItemLocalPositionInGrid(Vector2Int itemPosInGrid)
    {
        return new Vector3(itemPosInGrid.x * gridComp.cellSize, itemPosInGrid.y * gridComp.cellSize);
    }

    public void ClearItem(Item item)
    {
        item.ClearItem(GetEmptyItemIdentifier());
    }

    public void UpgradeItem(Vector3 itemPos)
    {
        Item item = GetItemFromLocalPos(itemPos);
        int currLevel = item.itemIdentifier.level;

        if(currLevel + 1 > maxLevel) {
            AddScore();
            ClearItem(item);
        }else {
            item.UpdateData(item.posInGrid, itemsSelectionList.itemTypes[item.itemIdentifier.typeIndex].items[currLevel + 1]);
        }
    }

    private void AddScore()
    {
        Debug.Log("Score up!");
        // For adding score points
    }

    public Item GetItemFromLocalPos(Vector3 localPos)
    {
        Vector2Int itemGridPos = GetGridPosFromItemLocalPos(localPos);
        return gridArray[itemGridPos.x, itemGridPos.y];
    }

    // ================Private methods=============================

    ItemIdentifier GetEmptyItemIdentifier()
    {
        return itemsSelectionList.itemTypes[0].items[0];
    }

}
