using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void MoveAction(float angle);
    public event MoveAction Move;
    public delegate void RetreatAction();
    public event RetreatAction Retreat;
    public delegate void FireAction();
    public event FireAction Fire;
    private Dictionary<string, KeyCode> Keys;
    public void setKeys(Dictionary<string, KeyCode> newKeys)
    {
        if (Keys == null) Keys = newKeys;
    }

    // TODO: Recognize That Stuff 👇 (it shoud be just one line to control those actions).

    void Update()
    {
        if (Input.GetKeyDown(Keys["UP"]))
            Move?.Invoke(Mathf.PI / 2);
        if (Input.GetKeyDown(Keys["LEFT"]))
            Move?.Invoke(Mathf.PI);
        if (Input.GetKeyDown(Keys["DOWN"]))
            Move?.Invoke(3 * Mathf.PI / 2);
        if (Input.GetKeyDown(Keys["RIGHT"]))
            Move?.Invoke(0);

        if (Input.GetKeyDown(Keys["RETREAT"]))
            Retreat?.Invoke();

        if (Input.GetKeyDown(Keys["Fire"]))
            Fire?.Invoke();
    }
}