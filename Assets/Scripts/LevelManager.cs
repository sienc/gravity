using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    //private Scene[] levels;
    private string[] levels;

    public int levelCount { get { return levels != null ? levels.Length : 0; } }

    Scene loadedLevel;
    bool hasLoadedLevel;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel(int levelIndex)
    {
        if (hasLoadedLevel)
        {
            SceneManager.UnloadSceneAsync(loadedLevel);
            hasLoadedLevel = false;
        }

        SceneManager.LoadScene(levels[levelIndex], LoadSceneMode.Additive);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Additive)
        {
            hasLoadedLevel = true;
            loadedLevel = scene;
        }
    }
}
