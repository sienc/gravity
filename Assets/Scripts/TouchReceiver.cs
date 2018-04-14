using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchReceiver : MonoBehaviour
{
    public GameObject obj;

    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj != null)
        {
            var active = Input.GetMouseButton(0);
            obj.SetActive(active);

            if (active)
            {
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                var plane = new Plane(Vector3.forward, Vector3.zero);
				
                float enter;
                if (plane.Raycast(ray, out enter))
                    obj.transform.position = ray.GetPoint(enter);
            }
        }
    }
}
