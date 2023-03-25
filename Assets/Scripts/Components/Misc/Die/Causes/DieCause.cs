using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DieCause : MonoBehaviour
{
    [SerializeField] public DieMethod dieMethod;
    public delegate void DetectedCauseAction();
    public event DetectedCauseAction OnDieCauseLethal;

    protected void OnDetectedDieCause(object parameters = null)
    {
        if (isDieCauseLethal(parameters))
            OnDieCauseLethal?.Invoke();
    }

    protected abstract bool isDieCauseLethal(object parameters);
}
