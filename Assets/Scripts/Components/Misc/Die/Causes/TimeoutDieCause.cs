using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeoutDieCause : DieCause
{
    private float timeElapsed = 0;
    [SerializeField] public float timeoutTime = 3;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        OnDetectedDieCause();
    }
    protected override bool isDieCauseLethal(object parameters)
    {
        return timeElapsed > timeoutTime;
    }
}
