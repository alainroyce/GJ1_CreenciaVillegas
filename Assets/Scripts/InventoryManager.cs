using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Items> Item = new List<Items>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ListItems();
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    public void Add(Items item)
    {
        Item.Add(item);
    }

    public void Remove(Items item)
    {
        Item.Remove(item);
    }
    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Item)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }

}
