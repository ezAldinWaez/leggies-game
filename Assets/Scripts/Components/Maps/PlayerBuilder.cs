using UnityEngine;
public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] public GameObject[] playerPrefabs;
    public int playersCount { get; private set; }
    public delegate void InstantiatePlayerAction(GameObject newPlayer, int playerNumber);
    public static event InstantiatePlayerAction OnInstantiatePlayer;

    private void Start()
    {
        playersCount = playerPrefabs.Length;
        for (int playerNumber = 0; playerNumber < playersCount; playerNumber++)
        {
            GameObject newPlayer = BuildPlayer(playerNumber);
            OnInstantiatePlayer?.Invoke(newPlayer, playerNumber);
        }
    }
    private GameObject BuildPlayer(int playerNumber)
    {
        GameObject newPlayer = Instantiate(playerPrefabs[playerNumber]);
        return newPlayer;
    }
}