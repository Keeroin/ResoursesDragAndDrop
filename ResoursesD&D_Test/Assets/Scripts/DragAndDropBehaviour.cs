using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropBehaviour : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GridManager gridManager;
    Item item;
    
    Vector2 grabOffset;
    Vector3 itemGrabPos => transform.localPosition + gridManager.halfCellSize;


    void Start()
    {
        gridManager = GameObject.Find("Grid").GetComponent<GridManager>();
        item = GetComponent<Item>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item.itemIdentifier != null) {
            transform.position = eventData.position - grabOffset;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item.itemIdentifier != null) {
            grabOffset.x = eventData.position.x - transform.position.x;
            grabOffset.y = eventData.position.y - transform.position.y;

            transform.SetParent(transform.parent.parent);
        } 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(gridManager.gameObject.transform);

        if (gridManager.IsItemInGridSpace(itemGrabPos) && 
            gridManager.GetGridPosFromItemLocalPos(itemGrabPos) != item.posInGrid &&
            gridManager.IsItemsAreEqual(item, itemGrabPos)) {
            
            Item upgradeItem = gridManager.GetItemFromLocalPos(itemGrabPos);
            gridManager.UpgradeItem(upgradeItem);
            gridManager.ClearItem(item);
            gridManager.MoveToGridPos(item, item.posInGrid);
        }else {
            gridManager.MoveToGridPos(item, item.posInGrid);
        }
    }
}
