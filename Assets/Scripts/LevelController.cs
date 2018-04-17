using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject cube;

    public void Win()
    {
        Debug.Log("Win!");
        cube.gameObject.SetActive(false);
		//ShowMessage("YOU WIN!");
    }

    public void Lose()
    {
        Debug.Log("Lose!");

        cube.gameObject.SetActive(false);
		//ShowMessage("Your cube is devoured by the black hole.\nTry again.");
    }

    public void Reset()
    {
        cube.transform.position = Vector3.zero;
		cube.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cube.gameObject.SetActive(true);
    }

    // void ShowMessage(string text)
    // {
    //     message.text = text;
    //     message.gameObject.SetActive(true);
    // }
}
