using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigerZone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}
