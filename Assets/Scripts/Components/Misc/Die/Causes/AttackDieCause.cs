using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDieCause : DieCause
{
    // TODO: Make docs about this.
    protected override bool isDieCauseLethal(object othersTimeSinceLastAttack)
    {
        if (!(othersTimeSinceLastAttack is float))
        {
            Debug.Log("AttackDieCause takes a float.");
            return false;
        }
        Attack myAttack = this.GetComponentInChildren<Attack>();
        return (myAttack == null || myAttack.timeSinceLastAttack > (float)othersTimeSinceLastAttack);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Attack otherAttack = other.GetComponent<Attack>();
        if (otherAttack == null) return;
        float othersTimeSinceLastAttack = otherAttack.timeSinceLastAttack;
        OnDetectedDieCause(othersTimeSinceLastAttack);
    }
}
