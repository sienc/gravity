using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Camera dummyCamera;

    [SerializeField]
    private string[] levels;

    public int levelCount { get { return levels != null ? levels.Length : 0; } }
    public int currentLevelIndex { get; set; }
    public event Action levelCompleted;
    public event Action levelFailed;

    Scene loadedLevel;
    bool hasLoadedLevel;
    LevelController levelController;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void Load(int levelIndex)
    {
        Unload();
        SceneManager.LoadScene(levels[levelIndex], LoadSceneMode.Additive);
        currentLevelIndex = levelIndex;
    }

    public void Reload()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        Unload();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Additive);
    }

    public void Unload()
    {
        if (hasLoadedLevel)
        {
            SceneManager.UnloadSceneAsync(loadedLevel);
            hasLoadedLevel = false;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dummyCamera.gameObject.SetActive(false);

        SceneManager.SetActiveScene(scene);

        hasLoadedLevel = true;
        loadedLevel = scene;

        var gc = GameObject.FindGameObjectWithTag("GameController");
        levelController = gc.GetComponent<LevelController>();

        levelController.onLevelComplete.AddListener(() => { if (levelCompleted != null) levelCompleted(); });
        levelController.onLevelFail.AddListener(() => { if (levelFailed != null) levelFailed(); });
    }

    void OnSceneUnloaded(Scene scene)
    {
        dummyCamera.gameObject.SetActive(true);
    }
}
