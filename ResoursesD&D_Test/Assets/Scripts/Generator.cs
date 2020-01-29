using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridManager))]
public class Generator : MonoBehaviour
{
    public GridManager gridManager;

    void Start()
    {
        gridManager = GetComponent<GridManager>();
    }

    public void GenerateItem()
    {
        List<Item> items = new List<Item>();

        foreach (var item in gridManager.items) {
            if (item.itemIdentifier.itemType == 0)
                items.Add(item);
            else continue;
        }

        if (items.Count == 0) return;

        int itemIndex = Random.Range(0, items.Count - 1);
        items[itemIndex].itemIdentifier = ChooseResourse();
        gridManager.UpgradeItem(items[itemIndex]);
    }

    public ItemIdentifier ChooseResourse()
    {
        int itemTypeInd = Random.Range(1, gridManager.itemsSelectionList.itemTypes.Count - 1);
        int itemLvlInd = Random.Range(0, 1);
        
        return gridManager.itemsSelectionList.itemTypes[itemTypeInd].items[itemLvlInd];
    }
}
