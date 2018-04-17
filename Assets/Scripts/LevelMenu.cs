using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform levelContainer;

    [SerializeField]
    private GameObject levelButtonPrefab;

    public void Init(int levelCount, int unlockedLevel, Action<int> onClick)
    {
        foreach (Transform obj in levelContainer)
            Destroy(obj.gameObject);

        for (var i = 0; i < levelCount; i++)
        {
            var obj = Instantiate(levelButtonPrefab);
            obj.transform.SetParent(levelContainer);

            var button = obj.GetComponentInChildren<Button>();
            var text = obj.GetComponentInChildren<Text>();

            var enable = i <= unlockedLevel;

            button.enabled = enable;
            text.text = enable ? (i+1).ToString("00") : "X";

            if (enable)
            {
                var level = i;
                button.onClick.AddListener(() => onClick(level));
            }
        }
    }

}
