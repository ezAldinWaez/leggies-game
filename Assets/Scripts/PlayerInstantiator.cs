using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiator : MonoBehaviour
{
    [SerializeField] private int playersCount = 4;
    [SerializeField] private GameObject[] playerPrefab;
    public delegate void InstantiatePlayerAction(GameObject newPlayer);
    public static event InstantiatePlayerAction OnInstantiatePlayer;
    private void Start()
    {
        for (int i = 0; i < playersCount; i++)
        {
            InstantiatePlayer(InputDictionaries.GetPlayerKeys(i), new Vector3(i, 0, 0), i);
        }
    }

    private void InstantiatePlayer(Dictionary<string, KeyCode> keys, Vector3 initialPosition, int playerNumber)
    {
        GameObject player = Instantiate(playerPrefab[playerNumber], initialPosition, Quaternion.identity);
        player.AddComponent(typeof(PlayerInput));
        player.GetComponent<PlayerInput>().setKeys(keys);
        OnInstantiatePlayer?.Invoke(player);
    }
}