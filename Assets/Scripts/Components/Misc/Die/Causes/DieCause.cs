using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DieCause : MonoBehaviour
{
    // TODO: Make docs about this.
    [SerializeField] public DieMethod dieMethod;
    public delegate void DetectedCauseAction();
    public event DetectedCauseAction OnDieCauseLethal;

    public void OnDetectedDieCause(object parameters = null)
    {
        if (isDieCauseLethal(parameters))
            OnDieCauseLethal?.Invoke();
    }

    protected abstract bool isDieCauseLethal(object parameters);
}
