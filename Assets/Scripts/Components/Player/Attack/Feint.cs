using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class Feint : MonoBehaviour
{
    [SerializeField] private float feintDuration = 0.25f;
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
            Invoke("DisableFeint", feintDuration);
        }
    }

    void DisableFeint()
    {
        if (!attack.isAttacking)
            SetFeintState(false);
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    private void SetFeintState(bool state)
    {
        this.GetComponent<SpriteRenderer>().enabled = state;
    }
    private void SetFeintSize()
    {
        float newSize = attack.attackDuration + 1;
        this.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
}