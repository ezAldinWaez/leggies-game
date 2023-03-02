using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DieCause : MonoBehaviour
{
    // TODO: Make docs about this.
    public delegate void DetectedCauseAction();
    public event DetectedCauseAction OnDieCause;

    public void OnDetectedDieCause(Dictionary<string, float> parameters = null)
    {
        if (isDieCauseLethal(parameters))
            OnDieCause?.Invoke();
    }

    protected abstract bool isDieCauseLethal(Dictionary<string, float> parameters);
}
