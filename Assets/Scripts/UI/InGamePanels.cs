using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanels : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private Text textBox;
    [SerializeField] private float timeStart = 480;
    [SerializeField] private float timer;

    void Start()
    {
        EventBroadcaster.Instance.PrintObservers();
        textBox.text = timeStart.ToString();
        timer = timeStart;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        textBox.text = Mathf.Round(timer).ToString();

        if (Inventory.Instance.items.Count == 20)
        {
            isWin();
        }
        else if (timer <= 0)
        {
            isLose();
        }
    }

    private void isWin()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    private void isLose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void isMainMenuPressed()
    {
        Inventory.Instance.ClearInventory();
        Time.timeScale = 1;
        LoadManager.Instance.LoadScene("MainMenu");
    }
    public void isRestartPressed()
    {
        Inventory.Instance.ClearInventory();
        Time.timeScale = 1;
        LoadManager.Instance.LoadScene("GameScene");
    }
}
