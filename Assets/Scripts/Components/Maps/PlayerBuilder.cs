using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] public GameObject[] playerPrefabs;
    public delegate void InstantiatePlayerAction(GameObject newPlayer, int playerIndex);
    public static event InstantiatePlayerAction OnInstantiatePlayer;

    private void Start()
    {
        List<int> selectedPlayers = GetSelectedPlayers();
        foreach (int playerIndex in selectedPlayers)
            OnInstantiatePlayer?.Invoke(Instantiate(playerPrefabs[playerIndex]), playerIndex);
    }

    private List<int> GetSelectedPlayers()
    {
        List<int> selectedPlayers = new();
        for (int i = 0; i < playerPrefabs.Length; i++)
            if (PlayerPrefs.GetInt("Player" + i.ToString()) == 1)
                selectedPlayers.Add(i);
        return selectedPlayers;
    }

}