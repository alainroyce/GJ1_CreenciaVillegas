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

    private void Awake()
    {
        Time.timeScale = 1;
        EventBroadcaster.Instance.PrintObservers();
    }

    void Start()
    {
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
        Cursor.lockState = CursorLockMode.None;
        AudioManager.instance.Play("win");
        Time.timeScale = 0;
    }

    private void isLose()
    {
        LosePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        AudioManager.instance.Play("lose");
        Time.timeScale = 0;
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
