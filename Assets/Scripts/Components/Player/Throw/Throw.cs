using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeggiesLibrary;


[RequireComponent(typeof(PlayerInput))]
public class Throw : MonoBehaviour
{
    // TODO: Make docs about this.
    // TODO: Make ThrowAccessories and use it to play the sound instead of in Throwable.
    [SerializeField] private float cooldownDuration = 1;
    [SerializeField] private bool willSoundOnThrow = true;
    [SerializeField] private bool willShake = true;
    [SerializeField] private float minShake = -0.5f, maxShake = 0.3f;
    [SerializeField] private GameObject throwableAttack;
    [SerializeField] private float flyPower = 400;
    private float timeSinceLastThrow;
    private PlayerInput playerInput;

    private void Start()
    {
        if (throwableAttack == null)
        {
            Debug.Log("Dude, you need to have a throwable attack to throw it!\nBy the way, I'm '" + this.name + "'.");
            return;
        }
        timeSinceLastThrow = cooldownDuration;
        playerInput = this.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += OnReceiveInput;
    }

    private void Update()
    {
        timeSinceLastThrow += Time.deltaTime;
    }

    void OnReceiveInput(InputName key)
    {
        if (key == InputName.THROW)
            EnableThrow();
    }

    void EnableThrow()
    {
        bool canMakeThrow = (timeSinceLastThrow >= cooldownDuration);
        if (canMakeThrow)
        {
            Vector3 forceUnitVector = LeggiesMath.RandomDirectionUnitVector2();
            Vector3 spawnPos = this.transform.position + 2 * forceUnitVector;
            GameObject thrownAttack = Instantiate<GameObject>(throwableAttack, spawnPos, Quaternion.identity);
            Vector2 flyForce = forceUnitVector * flyPower;
            thrownAttack.GetComponent<Throwable>().Boom(willSoundOnThrow, willShake, minShake, maxShake, flyForce);
            timeSinceLastThrow = 0;
        }
    }
}
