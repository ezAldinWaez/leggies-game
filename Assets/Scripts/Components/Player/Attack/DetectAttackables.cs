using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class DetectAttackables : MonoBehaviour
{
    // TODO: Update docs about this.
    private void OnTriggerEnter2D(Collider2D other)
    {
        float timeSinceLastAttack = this.GetComponent<Attack>().timeSinceLastAttack;
        Dictionary<string, float> parameters = new();
        parameters["othersTimeSinceLastAttack"] = timeSinceLastAttack;
        other.gameObject.GetComponent<AttackDieCause>()?.OnDetectedDieCause(parameters);
    }
}
