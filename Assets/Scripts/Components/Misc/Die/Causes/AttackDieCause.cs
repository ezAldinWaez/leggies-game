using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDieCause : DieCause
{
    // TODO: Make docs about this.
    protected override bool isDieCauseLethal(Dictionary<string, float> parameters)
    {
        if (!parameters.ContainsKey("othersTimeSinceLastAttack"))
        {
            Debug.Log("Dude, we need othersTimeSinceLastAttack as a parameter to determine whether that timeout die cause is lethal or not.");
        }
        float othersTimeSinceLastAttack = parameters["othersTimeSinceLastAttack"];
        Attack myAttack = this.GetComponentInChildren<Attack>();
        return (myAttack == null || myAttack.timeSinceLastAttack > othersTimeSinceLastAttack);
    }
}
