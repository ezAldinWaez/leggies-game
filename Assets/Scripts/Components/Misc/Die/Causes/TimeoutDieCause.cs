using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeoutDieCause : DieCause
{
    // TODO: Make docs about this.
    private float timeElapsed = 0;
    [SerializeField] float timeoutTime = 3;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        OnDetectedDieCause();
    }
    protected override bool isDieCauseLethal(Dictionary<string, float> parameters)
    {
        return timeElapsed > timeoutTime;
    }
}
