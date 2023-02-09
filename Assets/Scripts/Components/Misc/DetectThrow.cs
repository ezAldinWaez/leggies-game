using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectThrow : MonoBehaviour
{
    // TODO: Make docs about this.
    public delegate void DetectedThrowAction();
    public event DetectedThrowAction OnThrown;
    public void OnDetectedThrow()
    {
        OnThrown?.Invoke();
    }
}
