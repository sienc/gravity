using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public UnityEvent onLevelComplete;
    public UnityEvent onLevelFail;

    public void Complete()
    {
        Debug.Log("Level completed");

        if (onLevelComplete != null)
            onLevelComplete.Invoke();
    }

    public void Fail()
    {
        Debug.Log("Level failed");

        if (onLevelFail != null)
            onLevelFail.Invoke();
    }
}
