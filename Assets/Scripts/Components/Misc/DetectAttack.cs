using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAttack : MonoBehaviour
{
    public delegate void DetectedAttackAction(bool isAttackLethal);
    public event DetectedAttackAction OnAttacked;
    public void OnDetectedAttack(float othersTimeSinceLastAttack)
    {
        OnAttacked?.Invoke(isAttackLethal(othersTimeSinceLastAttack));
    }
    private bool isAttackLethal(float othersTimeSinceLastAttack)
    {
        Attack myAttack = this.GetComponentInChildren<Attack>();
        if (myAttack == null)
            return true;
        if (myAttack.timeSinceLastAttack > othersTimeSinceLastAttack)
            return true;
        return false;
    }
}
