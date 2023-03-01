using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDieCause : DieCause<float>
{
    protected override bool isCauseLethal(float f = 0)
    {
        if (f != 0)
            throw new System.ArgumentException("Really? Throw is always lethal!");
        return true;
    }
}
