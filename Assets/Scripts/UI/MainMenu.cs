using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Panel;

    private void Start()
    {
        Panel.SetActive(false);
    }
    
    public void isStartPressed()
    {
        LoadManager.Instance.LoadScene("GameScene");
    }

    public void isInstructionsPressed()
    {
        Panel.SetActive(true);
    }
    public void isCloseInstructionsPressed()
    {
        Panel.SetActive(false);
    }
    public void isQuitPressed()
    {
        Application.Quit();
    }
}
