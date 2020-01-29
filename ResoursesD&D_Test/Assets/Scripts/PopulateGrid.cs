using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    GridManager gridManager;
    Generator itemGenerator;

    //Params
    [Space]
    [SerializeField] bool fillArray = true;
    public float offset = 2f;
    public float side = 80f;
    public int countOfCells = 5;

    public int cellSize => (int)(offset + side);
    public int halfCellSize => (int)((offset + side) * .5);
    public Vector3 endPoint;
    
    void Start()
    {
        endPoint = new Vector3(cellSize * countOfCells, cellSize * countOfCells);
        gridManager = GetComponent<GridManager>();

        if (gridManager == null)
            fillArray = false;

        if (fillArray) {
            itemGenerator = GetComponent<Generator>();
            itemGenerator.gridManager = gridManager;
        }

        Populate();
    }


    void Populate()
    {
        transform.localPosition += new Vector3(offset, offset);

        GameObject itemObj;
        
        for(int y = 0; y < 5; y++) {
            for (int x = 0; x < 5; x++) {
                itemObj = Instantiate(itemPrefab, transform);
                itemObj.transform.localPosition = new Vector3(cellSize * x, cellSize * y);

                if (fillArray)
                    AddItemInGrid(itemObj, new Vector2Int(x, y));
            }
        }
    }

    void AddItemInGrid(GameObject itemObj, Vector2Int posInGrid)
    {
        Item currItem = itemObj.GetComponent<Item>();
        if (Random.Range(0, 2) == 0)
            currItem.UpdateData(posInGrid, itemGenerator.ChooseResourse());
        else
            currItem.UpdateData(posInGrid, gridManager.GetEmptyItemIdentifier());

        gridManager.SetItemInArray(posInGrid, currItem);
    }


}
