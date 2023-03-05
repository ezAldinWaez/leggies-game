using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;

public class PlaySoundDieAccessory : DieAccessory
{
    // TODO: Make docs about this.
    [SerializeField] public AudioClip[] deathSounds;
    protected override void AccessoryAction()
    {
        if (deathSounds.Length == 0)
        {
            Debug.Log("\"willMakeSoundWhenDead = true\" and you didn't give any sound. \n What, am I supposed to make up some sound and play it?????\nBy the way, the offender is " + this.name + ".");
            return;
        }
        LeggiesSounds.PlayRandomSoundFrom(deathSounds);
    }
}
