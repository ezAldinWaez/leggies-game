using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeoutDieCause : DieCause<float>
{
    private float timeElapsed = 0;
    [SerializeField] float timeoutTime = 3;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        OnDetectedCause(timeElapsed);
    }
    protected override bool isCauseLethal(float timeElapsed)
    {
        return timeElapsed > timeoutTime;
    }
}
