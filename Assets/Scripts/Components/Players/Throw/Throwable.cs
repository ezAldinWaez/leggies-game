using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TimeoutDieCause))]
public class Throwable : MonoBehaviour
{
    private bool willSoundOnThrow;
    private AudioClip throwClip;
    private bool willShake;
    private float minShake, maxShake;
    private Vector2 flyForce;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = this.transform.localScale;
    }

    public void Boom(bool willSoundOnThrow, AudioClip throwClip, bool willShake, float minShake, float maxShake, Vector2 flyForce)
    {
        this.willSoundOnThrow = willSoundOnThrow;
        this.throwClip = throwClip;
        this.willShake = willShake;
        this.minShake = minShake;
        this.maxShake = maxShake;
        this.flyForce = flyForce;
        Boom();
    }

    private void Boom()
    {
        this.GetComponent<Rigidbody2D>().AddForce(flyForce);
        if (willSoundOnThrow)
            LeggiesSounds.PlaySoundFrom(throwClip);
    }

    void Update()
    {
        if (willShake)
            this.transform.localScale = LeggiesMath.ShakeVector3(originalScale, minShake, maxShake);
    }

}
