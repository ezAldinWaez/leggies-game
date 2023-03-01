using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDieCause : DieCause<float>
{
    protected override bool isCauseLethal(float othersTimeSinceLastAttack)
    {
        Attack myAttack = this.GetComponentInChildren<Attack>();
        if (myAttack == null)
            return true;
        if (myAttack.timeSinceLastAttack > othersTimeSinceLastAttack)
            return true;
        return false;
    }
}
