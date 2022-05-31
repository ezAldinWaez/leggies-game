using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBuilder))]
public class PlayerInputSetter : MonoBehaviour
{
    private void Awake()
    {
        PlayerBuilder.OnInstantiatePlayer += SetPlayerInput;
    }

    private void SetPlayerInput(GameObject newPlayer, int playerNumber)
    {
        // TODO: Don't get them from the defaul location; use PlayerPreferences
        Dictionary<InputName, KeyCode> newPlayerKeys = DefaultInputDictionaries.defaultKeysOfPlayer[playerNumber];
        newPlayer.AddComponent<PlayerInput>().setKeys(newPlayerKeys);
    }
}