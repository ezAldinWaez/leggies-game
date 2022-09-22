using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Die))]
[RequireComponent(typeof(Rigidbody2D))]
public class FlyAwayAfterDying : MonoBehaviour
{
    [SerializeField] private float flyPower = 150;
    void Start()
    {
        this.GetComponent<Die>().OnDying += FlyAway;
        this.GetComponent<Die>().DelegateDeath();
    }

    private void FlyAway(){
        float angle = Random.Range(0.0f, 2 * Mathf.PI);
        Vector2 forceToAdd = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * flyPower;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //To allow static things like ground to fly.
        this.GetComponent<Rigidbody2D>().AddForce(forceToAdd, ForceMode2D.Impulse);
        Invoke("DeleteObject", 1.0f);
    }

    private void DeleteObject() {Object.Destroy(this.gameObject);}
}
