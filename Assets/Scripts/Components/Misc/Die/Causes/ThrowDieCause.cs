using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDieCause : DieCause
{
    // TODO: Make docs about this.
    protected override bool isDieCauseLethal(Dictionary<string, float> parameters)
    {
        return true;
    }
}
