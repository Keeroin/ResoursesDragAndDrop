using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] ItemIdentifier item;

    Image itemImage;
    public Vector2Int posInGrid;
    public Vector2 posInLocalSpace;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponent<Image>();
        itemImage.sprite = item.sprite;
    }

}
