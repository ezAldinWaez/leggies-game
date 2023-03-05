using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyDieMethod : DieMethod
{
    // TODO: Make docs about this.
    [SerializeField] float flyPower = 400;
    public override void Die()
    {
        Vector2 forceToAdd = LeggiesMath.RandomDirectionUnitVector2() * (float)flyPower;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //To allow static things like ground to fly.
        this.GetComponent<Rigidbody2D>().AddForce(forceToAdd, ForceMode2D.Impulse);
        Invoke("DeleteObject", 1.0f);
    }
}
