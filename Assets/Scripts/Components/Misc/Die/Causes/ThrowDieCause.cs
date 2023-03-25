using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDieCause : DieCause
{
    protected override bool isDieCauseLethal(object parameters)
    {
        return true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Throwable otherThrowable = other.transform.GetComponent<Throwable>();
        if (otherThrowable == null) return;
        OnDetectedDieCause();
    }
}
