using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ThrowableFly : MonoBehaviour
{
    // TODO: Make docs about this.
    // TODO: Make a misc fly component that makes thething fly in a random direction on start
    private float throwDuration;
    private bool willSoundOnThrow;
    private bool willShake;
    private float minShake, maxShake;
    private Vector2 flyForce;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = this.transform.localScale;
    }

    public void Boom(float throwDuration, bool willSoundOnThrow, bool willShake, float minShake, float maxShake, Vector2 flyForce)
    {
        this.throwDuration = throwDuration;
        this.willSoundOnThrow = willSoundOnThrow;
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
        {
            AudioSource source = this.GetComponent<AudioSource>();
            if (source == null || source.clip == null)
            {
                Debug.Log("The throwable's AudioSource or clip is null, thus, it is but incomprehensible for an unsentient throwable to make sound that satisfies thy mighty gourmet tastes. I thus thereby beseech thee for my audio clip's restoration. Sincerely, " + this.name + ".");
                return;
            }
            source.Play(0);
        }
        Die myDie = this.gameObject.GetComponent<Die>();
        myDie.timeoutLimit = throwDuration;
    }

    void Update()
    {
        if (willShake)
            this.transform.localScale = LeggiesMath.ShakeVector3(originalScale, minShake, maxShake);
    }

}
