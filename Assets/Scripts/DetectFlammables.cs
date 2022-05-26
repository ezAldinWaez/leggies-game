using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fire))]
public class DetectFlammables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<DealWithFire>()?.OnDetectedFire(this.GetComponent<Fire>().timeSinceLastFire);
    }
}
