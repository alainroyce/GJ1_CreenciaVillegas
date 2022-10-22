using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public GameObject deactivate;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        AudioManager.instance.Play("Pickup");
        Debug.Log("Picking up " + item.name);
        // Add to Inventory
        bool wasPickedUp = Inventory.Instance.Add(item, deactivate);

        if (wasPickedUp)
            Destroy(gameObject);
    }
}