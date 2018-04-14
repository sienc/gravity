using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public GameObject cube;
    public Text message;

	public static GameSystem instance;

    public void Win()
    {
        cube.gameObject.SetActive(false);
		ShowMessage("YOU WIN!");
    }

    public void Lose()
    {
        cube.gameObject.SetActive(false);
		ShowMessage("Your cube is devoured by the black hole.\nTry again.");
    }

    public void Reset()
    {
        message.gameObject.SetActive(false);
        cube.transform.position = Vector3.zero;
		cube.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cube.gameObject.SetActive(true);
    }

    void ShowMessage(string text)
    {
        message.text = text;
        message.gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {
		instance = this;
		Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
