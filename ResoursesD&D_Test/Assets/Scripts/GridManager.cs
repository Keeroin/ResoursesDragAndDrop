using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PopulateGrid))]
public class GridManager : MonoBehaviour
{
    PopulateGrid gridComponent;
    public Item[,] gridArray = new Item[5, 5];
    public List<ItemIdentifier> II;

    void Start()
    {
        gridComponent = GetComponent<PopulateGrid>();
    }



    public Vector3 GetItemLocalPositionInGrid(Item item)
    {
        return GetItemLocalPositionInGrid(item.posInGrid);
    }

    public Vector3 GetItemLocalPositionInGrid(Vector2Int itemPosInGrid)
    {
        return gridArray[itemPosInGrid.x, itemPosInGrid.y].transform.localPosition;
    }


    //public Vector2 GetItemWorldPosition(Item item)
    //{
    //    return GetItemWorldPosition(item.posInGrid);
    //}

    //public Vector2 GetItemWorldPosition(Vector2Int itemPosInGrid)
    //{
    //    return new Vector2(gridComponent.transform.position.x + itemPosInGrid.x * (gridComponent.offset + gridComponent.side),
    //                        gridComponent.transform.position.y + itemPosInGrid.y * (gridComponent.offset + gridComponent.side));
    //}


    public void DebugPrintItem()
    {
        DebugPrintItem(gridArray[0, 0]);
    }

    public void DebugPrintItem(Item item)
    {
        Debug.Log(GetItemLocalPositionInGrid(item));
    }
}
