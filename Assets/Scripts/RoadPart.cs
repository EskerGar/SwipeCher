using System;
using UnityEngine;

public class RoadPart : MonoBehaviour
{
        [SerializeField]private Transform prevPosition;
        
        // Back road part on start when became invisible
        private void OnBecameInvisible()
        {
                transform.position = prevPosition.position + new Vector3(0f, transform.localScale.y);
        }
}