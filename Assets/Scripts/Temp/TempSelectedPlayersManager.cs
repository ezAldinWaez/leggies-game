using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSelectedPlayersManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    private List<int> selectedPlayers = new List<int>();

    void Start()
    {
        SelectPlayer(0);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                LoadPlayScene();
            else
            {
                int promptedPlayerIndex = IndexOfPromptedPlayer();
                if (promptedPlayerIndex != -1 && !selectedPlayers.Contains(promptedPlayerIndex))
                    SelectPlayer(promptedPlayerIndex);
            }
        }
    }

    private void SelectPlayer(int playerIndex)
    {
        selectedPlayers.Add(playerIndex);
        playerPrefabs[playerIndex].GetComponent<SpriteRenderer>().enabled = true;
        playerPrefabs[playerIndex].GetComponent<Rigidbody2D>().WakeUp();
    }

    private int IndexOfPromptedPlayer()
    {
        for (int i = 1; i < DefaultInputDictionaries.defaultKeysOfPlayer.Count; i++)
            foreach (KeyCode key in DefaultInputDictionaries.defaultKeysOfPlayer[i].Values)
                if (Input.GetKeyDown(key))
                    return i;
        return -1;
    }

    private void LoadPlayScene()
    {
        for (int i = 0; i < playerPrefabs.Length; i++)
            PlayerPrefs.SetInt("Player" + i.ToString(), System.Convert.ToInt32(selectedPlayers.Contains(i)));
        SceneManager.LoadScene(1);
    }
}
