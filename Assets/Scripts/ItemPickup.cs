using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
     public Items Item;

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isPressed();
            
        }
    }
    void isPressed()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        if (hit.collider.gameObject.tag == "Items")
        {
            Pickup();
        }
       
        else if (hit.collider.gameObject.tag == "Cactus")
        {
            Pickup();
        }


       /* if (hit.transform.gameObject.tag == "Items")
        {
            Pickup();
        }
        if (hit.transform.gameObject.tag == "Cactus")
        {
            Pickup();
        }*/
    }
}


