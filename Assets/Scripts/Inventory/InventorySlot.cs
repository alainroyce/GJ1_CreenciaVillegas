using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text name;
    Item item;

    public void AddItem(Item newItem)
    {
        Debug.Log(newItem.name);
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.name = item.name;
        Debug.Log(icon.name);
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.name = null;
        icon.enabled = false;
    }
}
