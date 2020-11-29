using System;
using Arrow;
using UnityEngine;

public class BarrierBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var arrow = other.GetComponent<ArrowBehaviour>();
        if(arrow != null)
            arrow.DestroyArrow();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}