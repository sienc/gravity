using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayController : MonoBehaviour
{
    [SerializeField]
    private GameObject playingElements;

    [SerializeField]
    private GameObject winElements;

    public void SetPlaying(bool value)
    {
        playingElements.gameObject.SetActive(value);
        winElements.gameObject.SetActive(false);
    }

    public void OnWin()
    {
        playingElements.gameObject.SetActive(false);
        winElements.gameObject.SetActive(true);
    }

    void Start()
    {
        SetPlaying(true);
    }

}
