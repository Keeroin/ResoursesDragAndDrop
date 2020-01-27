using System.Collections.Generic;


[System.Serializable]
public class ItemsSelectionList
{
    public List<ItemVariety> itemTypes;
}

[System.Serializable]
public class ItemVariety
{
    public List<ItemIdentifier> items;
}
