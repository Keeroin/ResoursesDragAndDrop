
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    Item[,] gridArray = new Item[5,5];

    //Params
    [Space]
    [SerializeField] float offset = 3f;
    [SerializeField] float side = 80f;

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    private void Populate()
    {
        transform.position += new Vector3(offset, offset);

        GameObject itemObj;
        Item currItem;

        for(int y = 0; y < 5; y++) {
            for (int x = 0; x < 5; x++) {
                itemObj = Instantiate(itemPrefab, transform);
                itemObj.transform.localPosition = new Vector3((side + offset) * x, (side + offset) * y);

                currItem = itemObj.GetComponent<Item>();
                currItem.posInGrid = new Vector2(x, y);

                gridArray[x, y] = currItem;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
