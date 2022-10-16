using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePhone : MonoBehaviour
{
    [SerializeField] GameObject PhonePanel;
    [SerializeField] GameObject CameraPanel;
    [SerializeField] GameObject InventoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        PhonePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isPressed();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCamera();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventory();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hidePanel();
        }
        

    }

    void isPressed()
    {
        PhonePanel.SetActive(true);
    }
    void isCamera()
    {
        CameraPanel.SetActive(true);
    }
    void isInventory()
    {
        InventoryPanel.SetActive(true);
    }
    void hidePanel()
    {
        PhonePanel.SetActive(false);
        CameraPanel.SetActive(false);
        InventoryPanel.SetActive(false);
    }
}
