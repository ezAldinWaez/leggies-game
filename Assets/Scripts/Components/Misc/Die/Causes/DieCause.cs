using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DieCause<T> : MonoBehaviour
{
    public delegate void DetectedCauseAction();
    public event DetectedCauseAction OnCause;

    public void OnDetectedCause(T parameters)
    {
        if (isCauseLethal(parameters))
            OnCause?.Invoke();
    }

    protected abstract bool isCauseLethal(T parameters);
}
