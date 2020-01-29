using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PopulateGrid))]
public class GridManager : MonoBehaviour
{
    public ItemsSelectionList itemsSelectionList = new ItemsSelectionList();
    public Vector3 halfCellSize => gridComp.cellSize * .5f * Vector2.one;

    Item[,] gridArray = new Item[5, 5];
    const int maxLevel = 2;
    const int scoreAddPoints = 10;

    PopulateGrid gridComp;
    ScoreBehaviour scoreBehaviour;

    void Start()
    {
        gridComp = GetComponent<PopulateGrid>();
        scoreBehaviour = GameObject.Find("Score").GetComponent<ScoreBehaviour>();
    }

    public Item[,] items => gridArray;

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
        return item.itemIdentifier.itemType == 0;
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

    public Vector3 GetItemLocalPositionInGrid(Vector2Int itemPosInGrid)
    {
        return new Vector3(itemPosInGrid.x * gridComp.cellSize, itemPosInGrid.y * gridComp.cellSize);
    }

    public void ClearItem(Item item)
    {
        ChangeItemIndexInArray(item, item.posInGrid);
        item.ClearItem(item.posInGrid, GetEmptyItemIdentifier());
    }

    public void UpgradeItem(Vector3 itemPos)
    {
        UpgradeItem(GetItemFromLocalPos(itemPos));
    }

    public void UpgradeItem(Item item)
    {
        int currLevel = item.itemIdentifier.level;

        if(currLevel + 1 > maxLevel) {
            AddScore();
            ClearItem(item);
        }else {
            ChangeItemIndexInArray(item, item.posInGrid);
            item.UpdateData(item.posInGrid, itemsSelectionList.itemTypes[(byte)item.itemIdentifier.itemType].items[currLevel + 1]);
        }
    }

    void ChangeItemIndexInArray(Item item, Vector2Int gridPos)
    {
        gridArray[gridPos.x, gridPos.y] = item;
    }

    private void AddScore()
    {
        Debug.Log("Score up!");
        // For adding score points

        scoreBehaviour.AddScore(scoreAddPoints);
    }

    public Item GetItemFromLocalPos(Vector3 localPos)
    {
        Vector2Int itemGridPos = GetGridPosFromItemLocalPos(localPos);
        return gridArray[itemGridPos.x, itemGridPos.y];
    }

    public void SwapItems(Item origin, Vector3 otherItemLocalPos)
    {
        SwapItems(origin, GetItemFromLocalPos(otherItemLocalPos));
    }

    public void SwapItems(Item origin, Item another)
    {
        Vector2Int anotherGridPos = another.posInGrid;
        Vector2Int originGridPos = origin.posInGrid;

        ItemIdentifier originItId = itemsSelectionList.itemTypes[(byte)origin.itemIdentifier.itemType].items[origin.itemIdentifier.level];

        origin.posInGrid = anotherGridPos;
        another.posInGrid = originGridPos;

        MoveToGridPos(origin, origin.posInGrid);
        MoveToGridPos(another, another.posInGrid);
    }

    public void MoveToGridPos(Item item, Vector2Int posInGrid)
    {
        item.transform.localPosition = GetItemLocalPositionInGrid(posInGrid);
    }
    

    public ItemIdentifier GetEmptyItemIdentifier()
    {
        return itemsSelectionList.itemTypes[0].items[0];
    }

}
