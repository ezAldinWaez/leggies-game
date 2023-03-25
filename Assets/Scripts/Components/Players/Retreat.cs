using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class Retreat : MonoBehaviour
{
    [SerializeField] private float power = 2500;
    [SerializeField] private bool willMakeSoundWhenRetreating = true;
    [SerializeField] private AudioClip[] retreatSounds;
    void Start()
    {
        Rigidbody2D movedBody = this.GetComponent<Rigidbody2D>();
        PlayerInput playerInput = this.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += (InputName key) =>
        {
            if (key == InputName.RETREAT)
            {
                float angle = Mathf.Atan2(movedBody.velocity.y, movedBody.velocity.x);
                movedBody.velocity = new Vector2(0, 0);
                Vector2 movedForce = new Vector2(power * -Mathf.Cos(angle), power * -Mathf.Sin(angle));
                movedBody.AddForce(movedForce);
                if (willMakeSoundWhenRetreating) PlayRetreatSound();
            }
        };
    }
    private void PlayRetreatSound()
    {
        AudioSource source = this.GetComponent<AudioSource>() ? this.GetComponent<AudioSource>() : this.gameObject.AddComponent<AudioSource>();
        source.clip = retreatSounds[new System.Random().Next(0, retreatSounds.Length)];
        source.Play(0);
    }
}