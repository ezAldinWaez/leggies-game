using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiator : MonoBehaviour
{
    [SerializeField] private int playersCount = 4;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Sprite[] playerSprites;
    public delegate void InstantiatePlayerAction(GameObject newPlayer, int playerNumber);
    public static event InstantiatePlayerAction OnInstantiatePlayer;
    private void Start()
    {
        for (int playerNumber = 0; playerNumber < playersCount; playerNumber++)
        {
            InstantiatePlayer(InputDictionaries.GetPlayerKeys(playerNumber), new Vector3(playerNumber, 0, 0), playerNumber);
        }
    }

    private void InstantiatePlayer(Dictionary<KeyName, KeyCode> newPlayerKeys, Vector3 initialPosition, int playerNumber)
    {
        GameObject player = Instantiate(playerPrefab, initialPosition, Quaternion.identity);
        PlayerInput newPlayerInput = player.AddComponent<PlayerInput>();
        newPlayerInput.setKeys(newPlayerKeys);
        player.GetComponent<SpriteRenderer>().sprite = playerSprites[playerNumber];
        OnInstantiatePlayer?.Invoke(player, playerNumber);
    }
}