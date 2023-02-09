using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;

public class Die : MonoBehaviour
{
    // TODO: Update docs about this.
    // TODO: Split this into some components.
    [SerializeField] public bool willDieByAttack = true;
    [SerializeField] public bool willDieByThrow = true;
    [SerializeField] public bool willDieByTimeout = false;
    [SerializeField] public float timeoutLimit = 60;
    [SerializeField] public bool willMakeSoundWhenDead = true;
    [SerializeField] public AudioClip[] deathSounds;
    [SerializeField] public bool willFlyAwayAfterDying = true;
    [SerializeField] public float flyPower = 400;
    private bool delegateDeath = false;
    public delegate void DeathAction();
    public event DeathAction OnDying;

    private void Start()
    {
        if (willMakeSoundWhenDead)
        {
            if (deathSounds.Length == 0)
            {
                Debug.Log("\"willMakeSoundWhenDead = true\" and you didn't give any sound. \n What, am I supposed to make up some sound and play it?????\nBy the way, the offender is " + this.name + ".");
                return;
            }
            OnDying += PlayDeathSound;
        }
        if (willFlyAwayAfterDying)
        {
            OnDying += FlyAway;
            DelegateDeath();
        }

        if (willDieByTimeout)
        {
            Invoke("SelfDestruct", timeoutLimit);
        }

        if (willDieByAttack)
        {
            DetectAttack detectAttack = this.GetComponent<DetectAttack>();
            if (detectAttack == null)
            {
                Debug.Log("Dude, you need to detect attack to be able to die by attack.");
                return;
            }
            detectAttack.OnAttacked += SelfDestruct;
        }

        if (willDieByThrow)
        {
            DetectThrow detectThrow = this.GetComponent<DetectThrow>();
            if (detectThrow == null)
            {
                Debug.Log("Dude, you need to detect throw to be able to die by throw.");
                return;
            }
            detectThrow.OnThrown += SelfDestruct;
        }
    }

    private void PlayDeathSound()
    {
        LeggiesSounds.PlayRandomSoundFrom(deathSounds);
    }
    private void FlyAway()
    {
        Vector2 forceToAdd = LeggiesMath.RandomDirectionUnitVector2() * flyPower;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //To allow static things like ground to fly.
        this.GetComponent<Rigidbody2D>().AddForce(forceToAdd, ForceMode2D.Impulse);
        Invoke("DeleteObject", 1.0f);
    }

    private void DelegateDeath()
    {
        if (delegateDeath)
        {
            Debug.Log("Dude, like, you can't delegate death to more than one thing. \nThe offender is " + this.name + ".");
            return;
        }
        delegateDeath = true;
    }

    private void SelfDestruct()
    {
        if (this.GetComponent<PlayerInput>())
            this.GetComponent<PlayerInput>().enabled = false; //Because, wow. If death is delegated, you can still move!
        OnDying?.Invoke();
        if (!delegateDeath)
            DeleteObject();
    }

    private void SelfDestruct(bool condition)
    {
        if (condition)
            SelfDestruct();
    }

    private void DeleteObject()
    {
        Object.Destroy(this.gameObject);
    }

}
