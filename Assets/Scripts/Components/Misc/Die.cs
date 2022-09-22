using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] bool willDieByAttack = true;
    [SerializeField] AudioClip[] deathSounds;
    private bool willMakeSoundWhenDead = true, delegateDeath = false;
    public delegate void DeathAction();
    public event DeathAction OnDying;
    private AudioSource audioSource;

    private void Start()
    {
        if (willMakeSoundWhenDead)
        {
            if (deathSounds.Length == 0)
                Debug.Log("\"willMakeSoundWhenDead = true\" and you didn't give any sound. \n What, am I supposed to make up some sound and play it?????\nBy the way, the offender is " + this.name + ".");
            else
                OnDying += PlayDeathSound;
        }

        DetectAttack detectAttack = this.GetComponent<DetectAttack>();
        if (detectAttack != null && willDieByAttack)
            detectAttack.OnAttacked += (bool isAttackLethal) =>
            {
                if (isAttackLethal) SelfDestruct();
            };
    }

    public void DelegateDeath()
    {
        if (delegateDeath) Debug.Log("Dude, like, you can't delegate death to more than one thing. \nThe offender is " + this.name + ".");
        delegateDeath = true;
    }

    private void PlayDeathSound()
    {
        GameObject sounder = new GameObject();
        AudioSource source = sounder.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = deathSounds[new System.Random().Next(0, deathSounds.Length)];
        source.Play(0);
        Object.Destroy(sounder, source.clip.length);
    }
    private void SelfDestruct()
    {
        OnDying?.Invoke();
        if (!delegateDeath) Object.Destroy(this.gameObject);
    }

}
