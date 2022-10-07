using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    public Transform PlayerCamera;

    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;




    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
       
      
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            Door door = gameObject.GetComponent<Door>();
            
        }

    }
}
