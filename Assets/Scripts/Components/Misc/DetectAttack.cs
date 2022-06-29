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
    public bool isAttackLethal(float othersTimeSinceLastAttack) {
        if (this.transform.childCount == 0)
            return true;
        Attack myAttack = this.transform.GetChild(0).gameObject.GetComponent<Attack>();
        if (myAttack == null)
            return true;
        if (myAttack.timeSinceLastAttack > othersTimeSinceLastAttack)
            return true;
        return false;
        

    }
}
