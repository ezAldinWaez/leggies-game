using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDictionaries : MonoBehaviour
{
    //TODO: public static const string for each Key name
    private static List<Dictionary<string, KeyCode>> defaultKeysOfPlayer = new List<Dictionary<string, KeyCode>> {
        new Dictionary<string, KeyCode> {
            ["UP"] = KeyCode.W,
            ["LEFT"] = KeyCode.A,
            ["DOWN"] = KeyCode.S,
            ["RIGHT"] = KeyCode.D,
            ["RETREAT"] = KeyCode.Q,
            ["FIRE"] = KeyCode.E,
            ["FEINT"] = KeyCode.R
        },
        new Dictionary<string, KeyCode> {
            ["UP"] = KeyCode.Keypad8,
            ["LEFT"] = KeyCode.Keypad4,
            ["DOWN"] = KeyCode.Keypad5,
            ["RIGHT"] = KeyCode.Keypad6,
            ["RETREAT"] = KeyCode.Keypad9,
            ["FIRE"] = KeyCode.Keypad7,
            ["FEINT"] = KeyCode.KeypadPlus
        },
        new Dictionary<string, KeyCode> {
            ["UP"] = KeyCode.Y,
            ["LEFT"] = KeyCode.G,
            ["DOWN"] = KeyCode.H,
            ["RIGHT"] = KeyCode.J,
            ["RETREAT"] = KeyCode.T,
            ["FIRE"] = KeyCode.U,
            ["FEINT"] = KeyCode.I
        },
        new Dictionary<string, KeyCode> {
            ["UP"] = KeyCode.P,
            ["LEFT"] = KeyCode.L,
            ["DOWN"] = KeyCode.Semicolon,
            ["RIGHT"] = KeyCode.Quote,
            ["RETREAT"] = KeyCode.O,
            ["FIRE"] = KeyCode.LeftBracket,
            ["FEINT"] = KeyCode.RightBracket
        }
    };
    private static int playersCount;

    public static Dictionary<string, KeyCode> GetPlayerKeys(int playerNumber)
    {
        Dictionary<string, KeyCode> playerKeys = defaultKeysOfPlayer[playerNumber];
        return playerKeys;
    }
}