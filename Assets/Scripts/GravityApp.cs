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
    private OverlayController gameOverlay;

    [SerializeField]
    private LevelManager levelManager;

    void Start()
    {
        levelManager.levelCompleted += OnLevelCompleted;
        levelManager.levelFailed += OnLevelFailed;

        levelMenu.Init(8, 2, PlayLevel);
        ShowMainMenu();
    }

    public void StartGame()
    {
        PlayLevel(0);
    }

    public void ShowMainMenu()
    {
        levelManager.Unload();
        gameOverlay.SetPlaying(false);

        levelMenu.gameObject.SetActive(false);
        gameOverlay.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void ShowLevelMenu()
    {
        levelManager.Unload();
        gameOverlay.SetPlaying(false);

        mainMenu.gameObject.SetActive(false);
        gameOverlay.gameObject.SetActive(false);
        levelMenu.gameObject.SetActive(true);
    }

    public void PlayNextLevel()
    {
        if (levelManager.currentLevelIndex < levelManager.levelCount - 1)
        PlayLevel(levelManager.currentLevelIndex+1);
    }

    public void ReloadLevel()
    {
        gameOverlay.SetPlaying(true);
        levelManager.Reload();
    }

    private void OnLevelCompleted()
    {
        gameOverlay.OnWin();
    }

    private void OnLevelFailed()
    {

    }

    private void PlayLevel(int levelIndex)
    {
        mainMenu.gameObject.SetActive(false);
        levelMenu.gameObject.SetActive(false);

        levelManager.Load(levelIndex);

        gameOverlay.gameObject.SetActive(true);
        gameOverlay.SetPlaying(true);
    }
}
