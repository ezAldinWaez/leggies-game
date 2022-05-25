using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public float fireDuration { get; private set; } = 5;
    [SerializeField] public float cooldownDuration { get; private set; } = 7;
    public float timeSinceLastFire { get; private set; }
    public bool onFire { get; private set; } = false;
    private PlayerInput playerInput;
    private void Start()
    {
        timeSinceLastFire = fireDuration + cooldownDuration;
        playerInput = this.transform.parent.gameObject.GetComponent<PlayerInput>();
        playerInput.OnKeyPressed += EnableFire;
    }

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (onFire) ScaleFire();
    }

    void EnableFire(string key)
    {
        if (key == "FIRE" && timeSinceLastFire >= fireDuration + cooldownDuration)
        {
            playerInput.OnKeyPressed -= EnableFire;
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<PolygonCollider2D>().enabled = true;
            onFire = true;
            timeSinceLastFire = 0;
            Invoke("DisableFire", fireDuration);
        }
    }

    void DisableFire()
    {
        onFire = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PolygonCollider2D>().enabled = false;
        playerInput.OnKeyPressed += EnableFire;
        this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0, 0, 0.5f);
        Invoke("ReturnColor", cooldownDuration);
    }

    void ReturnColor()
    {
        this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void ScaleFire()
    {
        float newSize = fireDuration - timeSinceLastFire + 1;
        this.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
}
