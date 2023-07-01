using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] ItemType itemType;
    [SerializeField] int itemIndex;
    [SerializeField] Sprite itemSprite;

    public override int GetHashCode()
    {
        return itemName.GetHashCode() ^ itemType.GetHashCode() ^ itemIndex.GetHashCode() ^ itemSprite.GetHashCode();
    }

    public string GetItemName() { return itemName; }
    public ItemType GetItemType() { return itemType; }
    public int GetItemIndex() { return itemIndex; }
    public Sprite GetItemSprite() { return itemSprite; }
}
