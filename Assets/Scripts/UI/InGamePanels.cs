using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePanels : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;

    private void Update()
    {
        if(Inventory.Instance.items.Count == 1)
        {
            isWin();
        }
    }

    public void isWin()
    {
        WinPanel.SetActive(true);
    }
    public void isMainMenuPressed()
    {
        LoadManager.Instance.LoadScene("MainMenu");
    }
    public void isRestartPressed()
    {
        LoadManager.Instance.LoadScene("GameScene");
    }
}
