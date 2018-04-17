using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField]
    public UnityEvent triggerEnter2D;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerEnter2D != null)
            triggerEnter2D.Invoke();
    }
}
