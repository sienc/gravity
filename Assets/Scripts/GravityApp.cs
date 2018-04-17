using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityApp : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenu;

    [SerializeField]
    private LevelMenu levelMenu;

    [SerializeField]
    private LevelManager levelManager;

    void Start()
    {
        levelMenu.Init(8, 3, PlayLevel);
        ShowMainMenu();
    }

    public void StartGame()
    {
        levelManager.LoadLevel(0);
    }

    public void ShowMainMenu()
    {
        levelMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void ShowLevelMenu()
    {
        mainMenu.gameObject.SetActive(false);
        levelMenu.gameObject.SetActive(true);
    }

    private void PlayLevel(int levelIndex)
    {
        mainMenu.gameObject.SetActive(false);
        levelMenu.gameObject.SetActive(false);

        levelManager.LoadLevel(levelIndex);
    }
}
