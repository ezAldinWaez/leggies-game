using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakePerSecond = 0.0f;
    [SerializeField] private float minShake = -0.5f, maxShake = 0.5f;
    private float timeSinceLastShake = 0.0f; 
    private Vector2 shakedPosition = new Vector2(0.0f, 0.0f);

    void Start()
    {
        if (shakePerSecond > 1.0f)
        {
            shakePerSecond = 1.0f;
            Debug.Log("Dude? Probability is between 0.0 and 1.0. The offender is \n" + this.gameObject.name + ".");
        }
        if (shakePerSecond <= 0.0f)
        {
            Debug.Log("Dude? Can't shake like that. CameraShake is now disabled. The offender is \n" + this.gameObject.name + ".");
            this.enabled = false;
        }
    }

    void Update()
    {
        SetShakeFactor();
        MoveTowardsShakedPosition();
    }
    private void SetShakeFactor()
    {
        timeSinceLastShake += Time.deltaTime;
        float shakeTime = 1 / shakePerSecond;
        if (timeSinceLastShake > shakeTime)
        {
            shakedPosition = new Vector2(Random.Range(minShake, maxShake), Random.Range(minShake, maxShake));
            timeSinceLastShake = 0.0f;
        }
    }

    private void MoveTowardsShakedPosition(){
        
    }
}
