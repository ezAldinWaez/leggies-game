using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAttack : MonoBehaviour
{
    public delegate void DetectedAttackAction(float othersTimeSinceLastAttack);
    public event DetectedAttackAction OnAttacked;
    public void OnDetectedAttack(float othersTimeSinceLastAttack)
    {
        OnAttacked?.Invoke(othersTimeSinceLastAttack);
    }
}
