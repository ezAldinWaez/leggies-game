using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;

public class Die : MonoBehaviour
{
    // TODO: Split this into some components--Abstract DieCause and DieMethod, for each Cause a class that implements DieCause; for each Method a class that implements DieMethod (we have vanilla die and fly die). Each DieMethod has an array of Causes in which you add which Causes it will subscribe to. Each Cause must have one Method only that responds to its Event. Die subscribes to the Events of all Components of type DieMethod to emit its own general DieEvent for stuff to subscribe so.
    // TODO: Update docs about this.
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
        foreach (DieCause dieCause in this.GetComponents(typeof(DieCause)))
        {
            dieCause.OnDieCause += Dying;
        }
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

    private void Dying()
    {
        // Prevent Player Input
        if (this.GetComponent<PlayerInput>())
            this.GetComponent<PlayerInput>().enabled = false; //Because, wow. If death is delegated, you can still move!
        OnDying?.Invoke();
        if (!delegateDeath)
            DeleteObject();
    }

    private void DeleteObject()
    {
        Object.Destroy(this.gameObject);
    }

}
