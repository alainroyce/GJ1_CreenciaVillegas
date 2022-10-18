using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
 public Image icon;
    public Text name;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.name = item.name;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.name = null;
        icon.enabled = false;
    }
}
