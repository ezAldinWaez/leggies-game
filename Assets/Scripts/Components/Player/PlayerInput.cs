using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void KeyPressedAction(InputName key);
    public event KeyPressedAction OnKeyPressed;
    private Dictionary<InputName, KeyCode> Keys;
    public void setKeys(Dictionary<InputName, KeyCode> newKeys)
    {
        if (Keys == null) Keys = newKeys;
    }

    void Update()
    {
        if (Keys != null)
            foreach (KeyValuePair<InputName, KeyCode> key in Keys)
            {
                if (Input.GetKeyDown(key.Value)) OnKeyPressed?.Invoke(key.Key);
            }
    }
}