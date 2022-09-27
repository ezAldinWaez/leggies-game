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
    [SerializeField] private float scareProbability = 0.1f;
    [SerializeField] private bool willShake = true;
    [SerializeField] private float minShake = -0.5f, maxShake = 0.3f;

    private bool isFeinting = false, willScare = false;
    private Attack attack;
    private PlayerInput playerInput;

    private void Start()
    {
        if (scareProbability > 1.0f) {
            Debug.Log("Dude? Like, you can't have more than 100% for probability.\nThe offender is " + this.transform.parent.gameObject.name + "'s attack.");
            scareProbability = 1.0f;
        }
        if (scareProbability < 0.0f) {
            Debug.Log("Dude? Like, you can't have less than 0% for probability.\nThe offender is " + this.transform.parent.gameObject.name + "'s attack.");
            scareProbability = 0.0f;
        }
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
            willScare = Random.Range(0.0f, 1.0f) <= scareProbability;
            float waitDuration = willScare ? feintDuration + 0.2f * attack.GetAttackDuration() : feintDuration;
            if (willScare) StartAttackSound();
            Invoke("DisableFeint", waitDuration);
        }
    }
    void Update()
    {
        if (!attack.isAttacking && isFeinting && attack.GetWillShake() && willScare && willShake)
            this.transform.localScale = LeggiesMath.ShakeVector3(Vector3.one * (attack.GetAttackDuration() + 1), minShake, maxShake);
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