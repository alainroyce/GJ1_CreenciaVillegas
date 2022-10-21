using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanels : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private Text textBox;
    private float timeStart = 10;
    private float timer;
    public bool isGameOver = false;

    void Start()
    {
        EventBroadcaster.Instance.PrintObservers();
        textBox.text = timeStart.ToString();
        timer = timeStart;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            textBox.text = Mathf.Round(timer).ToString();

            if (Inventory.Instance.items.Count == 1)
            {
                isWin();
                isGameOver = true;
            }
            else if (timer <= 0)
            {
                isLose();
                isGameOver = true;
            }
        }
    }

    private void isWin()
    {
        WinPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    private void isLose()
    {
        LosePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void isMainMenuPressed()
    {
        Inventory.Instance.ClearInventory();
        LoadManager.Instance.LoadScene("MainMenu");
    }
    public void isRestartPressed()
    {
        Inventory.Instance.ClearInventory();
        LoadManager.Instance.LoadScene("GameScene");
    }
}
