using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class DetectAttackables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        float timeSinceLastAttack = this.GetComponent<Attack>().timeSinceLastAttack;
        other.gameObject.GetComponent<DetectAttack>()?.OnDetectedAttack(timeSinceLastAttack);
    }
}
