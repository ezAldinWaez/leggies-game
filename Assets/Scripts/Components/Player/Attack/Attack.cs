using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class Attack : MonoBehaviour
{
    [SerializeField] public float attackDuration { get; private set; } = 5;
    [SerializeField] public float cooldownDuration { get; private set; } = 7;
    [SerializeField] private Color cooldownColor = new Color(1, 0.78431374f, 0.78431374f, 1);
    public float timeSinceLastAttack { get; private set; }
    public bool isAttacking { get; private set; } = false;
    private PlayerInput playerInput;

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
            SetAttackScale();
    }

    void EnableAttack()
    {
        bool canMakeAttack = (timeSinceLastAttack >= attackDuration + cooldownDuration);
        if (canMakeAttack)
        {
            playerInput.OnKeyPressed -= OnReceiveInput;
            SetAttackState(true);
            timeSinceLastAttack = 0;
            Invoke("DisableAttack", attackDuration);
        }
    }

    void DisableAttack()
    {
        SetAttackState(false);
        playerInput.OnKeyPressed += OnReceiveInput;
        SetColor(cooldownColor);
        Invoke("SetColorWhite", cooldownDuration);
    }

    void SetAttackScale()
    {
        float newSize = attackDuration - timeSinceLastAttack + 1;
        this.transform.localScale = new Vector3(newSize, newSize, newSize);
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
}
