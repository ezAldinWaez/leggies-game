using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class Feint : MonoBehaviour
{
    [SerializeField] private float feintDuration = 0.25f;
    [SerializeField] private bool willShake = true;
    [SerializeField] private float minShake = -0.5f, maxShake = 0.3f;

    private bool isFeinting = false, willScare = false;
    private Attack attack;
    private PlayerInput playerInput;

    private void Start()
    {
        attack = this.GetComponent<Attack>();
        playerInput = this.transform.parent.gameObject.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += OnReceiveInput;
    }
    void OnReceiveInput(InputName key)
    {
        if (key == InputName.FEINT) EnableFeint();
    }
    void EnableFeint()
    {
        if (!attack.isAttacking)
        {
            isFeinting = true;
            playerInput.OnKeyPressed -= OnReceiveInput;
            SetFeintState(true);
            this.transform.localScale = Vector3.one * (attack.GetAttackDuration() + 1);
            willScare = new System.Random().Next(0, 10) < 1;
            float waitDuration = willScare ? feintDuration + 0.2f * attack.GetAttackDuration() : feintDuration;
            if (willScare) StartAttackSound();
            Invoke("DisableFeint", waitDuration);
        }
    }
    void Update()
    {
        if (!attack.isAttacking && isFeinting && attack.GetWillShake() && willScare && willShake)
            this.transform.localScale = Math.ShakeBaseVector(Vector3.one * (attack.GetAttackDuration() + 1), minShake, maxShake);
    }

    void DisableFeint()
    {
        isFeinting = false;
        if (!attack.isAttacking)
        {
            SetFeintState(false);
            if (willScare) StopAttackSound(); //Because if attacking, we want the sound to continue.
        }
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    private void SetFeintState(bool state)
    {
        this.GetComponent<SpriteRenderer>().enabled = state;
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