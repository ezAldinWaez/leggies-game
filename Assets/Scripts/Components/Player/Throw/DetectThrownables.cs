using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DetectThrownables : MonoBehaviour
{
    // TODO: Make docs about this.
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<DetectThrow>()?.OnDetectedThrow();
    }
}
