using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIt : MonoBehaviour
{
	public Vector3 rotationAxis = Vector3.up;
	public float rotationSpeed = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
