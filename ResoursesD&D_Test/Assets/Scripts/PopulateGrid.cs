
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    GridManager gridManager;

    //Params
    [Space]
    [SerializeField] bool fillArray = true;
    public float offset = 2f;
    public float side = 80f;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GetComponent<GridManager>();
        if (gridManager == null)
            fillArray = false;

        Populate();

    }


    void Populate()
    {
        transform.localPosition += new Vector3(2f, 2f);

        GameObject itemObj;
        
        for(int y = 0; y < 5; y++) {
            for (int x = 0; x < 5; x++) {
                itemObj = Instantiate(itemPrefab, transform);
                itemObj.transform.localPosition = new Vector3((side + offset) * x, (side + offset) * y);

                if (fillArray)
                    FillItemArray(itemObj, new Vector2Int(x, y));
            }
        }
    }

    void FillItemArray(GameObject itemObj, Vector2Int posInGrid)
    {
        Item currItem;
        currItem = itemObj.GetComponent<Item>();
        currItem.posInGrid = posInGrid;
        currItem.posInLocalSpace = itemObj.transform.localPosition;

        gridManager.gridArray[posInGrid.x, posInGrid.y] = currItem;
    }

}
