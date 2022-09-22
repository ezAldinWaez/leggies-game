using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class Feint : MonoBehaviour
{
    [SerializeField] private float feintDuration = 0.25f;
    private bool willScare = false;

    private Attack attack;
    private PlayerInput playerInput;

    void OnReceiveInput(InputName key)
    {
        if (key == InputName.FEINT)
            EnableFeint();
    }

    private void Start()
    {
        attack = this.GetComponent<Attack>();
        playerInput = this.transform.parent.gameObject.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    void EnableFeint()
    {
        if (!attack.isAttacking)
        {
            playerInput.OnKeyPressed -= OnReceiveInput;
            SetFeintState(true);
            SetFeintSize();
            willScare = new System.Random().Next(0, 10) < 1;
            float waitDuration = willScare ? feintDuration + 0.2f * attack.GetAttackDuration() : feintDuration;
            if (willScare) StartAttackSound();
            Invoke("DisableFeint", waitDuration);
        }
    }

    void DisableFeint()
    {
        if (!attack.isAttacking) {
            SetFeintState(false);
            if (willScare) StopAttackSound(); //Because if attacking, we want the sound to continue.
        }
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    private void SetFeintState(bool state)
    {
        this.GetComponent<SpriteRenderer>().enabled = state;
    }
    private void SetFeintSize()
    {
        float newSize = attack.GetAttackDuration() + 1;
        this.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
    private void StartAttackSound()
    {
        AudioSource source = attack.GetComponent<AudioSource>() ? attack.GetComponent<AudioSource>() : attack.gameObject.AddComponent<AudioSource>();
        source.clip = attack.GetAttackSoundStart();
        source.loop = false;
        source.Play(0);
        Invoke("LoopAttackSound", source.clip.length);
    }

    private void LoopAttackSound()
    {
        AudioSource source = attack.GetComponent<AudioSource>();
        source.Stop();
        source.clip = attack.GetAttackSoundLoop();
        source.loop = true;
        source.Play(0);
    }

    private void StopAttackSound()
    {
        AudioSource source = attack.GetComponent<AudioSource>();
        source.Stop();
        source.loop = false;
    }

}