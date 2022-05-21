using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDictionaries : MonoBehaviour
{
    private static List<Dictionary<string, KeyCode>> defaultKeysOfPlayer = new List<Dictionary<string, KeyCode>>();

    static InputDictionaries()
    {
        defaultKeysOfPlayer.Add(new Dictionary<string, KeyCode>()
        {
            ["UP"] = KeyCode.W,
            ["DOWN"] = KeyCode.S,
            ["RIGHT"] = KeyCode.D,
            ["LEFT"] = KeyCode.A,
            ["RETREAT"] = KeyCode.Q,
            ["FIRE"] = KeyCode.E,
            ["FEINT"] = KeyCode.F
        });
        defaultKeysOfPlayer.Add(new Dictionary<string, KeyCode>()
        {
            ["UP"] = KeyCode.UpArrow,
            ["DOWN"] = KeyCode.DownArrow,
            ["RIGHT"] = KeyCode.RightArrow,
            ["LEFT"] = KeyCode.LeftArrow,
            ["RETREAT"] = KeyCode.Keypad4,
            ["FIRE"] = KeyCode.Keypad5,
            ["FEINT"] = KeyCode.Keypad8
        });
        defaultKeysOfPlayer.Add(new Dictionary<string, KeyCode>()
        {
            ["UP"] = KeyCode.O,
            ["DOWN"] = KeyCode.L,
            ["RIGHT"] = KeyCode.Semicolon,
            ["LEFT"] = KeyCode.K,
            ["RETREAT"] = KeyCode.I,
            ["FIRE"] = KeyCode.P,
            ["FEINT"] = KeyCode.Quote
        });
        defaultKeysOfPlayer.Add(new Dictionary<string, KeyCode>()
        {
            ["UP"] = KeyCode.Y,
            ["DOWN"] = KeyCode.H,
            ["RIGHT"] = KeyCode.J,
            ["LEFT"] = KeyCode.G,
            ["RETREAT"] = KeyCode.T,
            ["FIRE"] = KeyCode.U,
            ["FEINT"] = KeyCode.B
        });
    }

    public static Dictionary<string, KeyCode> GetPlayerKeys(int playerNumber)
    {
        Dictionary<string, KeyCode> playerKeys = defaultKeysOfPlayer[playerNumber];
        
        // TODO: Do stuff.
        
        return playerKeys;
    }
}
