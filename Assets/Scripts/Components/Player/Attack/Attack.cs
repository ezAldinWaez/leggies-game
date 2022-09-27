using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class Attack : MonoBehaviour
{
    [SerializeField] private float attackDuration = 5, cooldownDuration = 7;
    [SerializeField] private Color cooldownColor = new Color(1, 0.78431374f, 0.78431374f, 1);
    [SerializeField] private bool willSoundOnAttack = true;
    [SerializeField] private AudioClip attackSoundStart, attackSoundLoop, attackSoundEnd;
    [SerializeField] private bool willShake = true;
    [SerializeField] private float minShake = -0.5f, maxShake = 0.3f;

    public float timeSinceLastAttack { get; private set; }
    public bool isAttacking { get; private set; } = false;
    private PlayerInput playerInput;

    public float GetAttackDuration() => attackDuration;
    public float GetCooldownDuration() => cooldownDuration;
    public bool GetWillSoundOnAttack() => willSoundOnAttack;
    public bool GetWillShake() => willShake;
    public AudioClip GetAttackSoundStart() => attackSoundStart;
    public AudioClip GetAttackSoundLoop() => attackSoundLoop;
    public AudioClip GetAttackSoundEnd() => attackSoundEnd;


    void OnReceiveInput(InputName key)
    {
        if (key == InputName.ATTACK)
            EnableAttack();
    }
    private void Start()
    {
        timeSinceLastAttack = attackDuration + cooldownDuration;
        playerInput = this.transform.parent.gameObject.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (isAttacking)
            if (willShake) this.transform.localScale = LeggiesMath.ShakeVector3(Vector3.one * (attackDuration - timeSinceLastAttack + 1), minShake, maxShake);
            else this.transform.localScale = Vector3.one * (attackDuration - timeSinceLastAttack + 1);
    }

    void EnableAttack()
    {
        bool canMakeAttack = (timeSinceLastAttack >= attackDuration + cooldownDuration);
        if (canMakeAttack)
        {
            if (willSoundOnAttack)
            {
                AudioSource source = this.GetComponent<AudioSource>() ? this.GetComponent<AudioSource>() : this.gameObject.AddComponent<AudioSource>();
                if (!source.isPlaying) StartAttackSound(); //Because it could be playing the loop from Feint.
            }
            playerInput.OnKeyPressed -= OnReceiveInput;
            SetAttackState(true);
            timeSinceLastAttack = 0;
            Invoke("DisableAttack", attackDuration);
        }
    }

    void DisableAttack()
    {
        if (willSoundOnAttack) StopAttackSound();
        SetAttackState(false);
        playerInput.OnKeyPressed += OnReceiveInput;
        SetColor(cooldownColor);
        Invoke("SetColorWhite", cooldownDuration);
    }

    private void SetAttackState(bool state)
    {
        this.GetComponent<SpriteRenderer>().enabled = state;
        this.GetComponent<PolygonCollider2D>().enabled = state;
        isAttacking = state;
    }

    private void SetColor(Color newColor)
    {
        this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }

    private void SetColorWhite()
    {
        SetColor(Color.white);
    }

    private void StartAttackSound()
    {
        AudioSource source = this.GetComponent<AudioSource>();
        source.clip = attackSoundStart;
        source.loop = false;
        source.Play(0);
        Invoke("LoopAttackSound", source.clip.length);
    }

    private void LoopAttackSound()
    {
        AudioSource source = this.GetComponent<AudioSource>();
        source.Stop();
        source.clip = attackSoundLoop;
        source.loop = true;
        source.Play(0);
    }

    private void StopAttackSound()
    {
        AudioSource source = this.GetComponent<AudioSource>();
        source.Stop();
        source.loop = false;
        if (attackSoundEnd != null)
        {
            source.clip = attackSoundEnd;
            source.Play(0);
        }
    }
}
