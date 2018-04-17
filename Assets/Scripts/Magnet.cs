using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float power = 1;

    List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();

    // Use this for initialization
    void Start()
    {
        var objs = GameObject.FindGameObjectsWithTag("Magnetic");
        foreach (var obj in objs)
        {
            var rigid = obj.GetComponent<Rigidbody2D>();
            if (rigid != null)
                rigidbodies.Add(rigid);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.position;

        foreach (var rigid in rigidbodies)
        {			
            if (rigid != null && rigid.gameObject.activeInHierarchy)
            {
                var dir = pos - rigid.transform.position;
                var dir2 = new Vector2(dir.x, dir.y);

                if (!Mathf.Approximately(dir2.magnitude, 0))
                {
                    //var mag = 1f / dir.sqrMagnitude;
                    var mag = 1f / dir.magnitude;

                    var force = dir2.normalized * mag * power;
                    rigid.AddForce(force);
                }
            }
        }
    }
}
