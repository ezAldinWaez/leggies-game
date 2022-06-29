using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    private float sizeMargin;
    private Vector2 minPlayersPosition, maxPlayersPosition;
    public float offset1X = 0.35f, offset1Y = -0.35f, offset2X = -0.35f, offset2Y = -0.75f;
    float distanceX, distanceY;
    bool isOutOfOffsetX, isOutOfOffsetY, isOutOfCenterX, isOutOfCenterY;
    private List<Transform> players = new();
    private void Awake()
    {
        sizeMargin = 0.004f * Mathf.Max(Screen.height, Screen.width);
        PlayerBuilder.OnInstantiatePlayer += (GameObject newPlayer, int playerNumber) =>
        {
            players.Insert(playerNumber, newPlayer.transform);
            RegisterPlayerRemovalFromPlayersListWhenDead(newPlayer);
        };
    }

    private void RegisterPlayerRemovalFromPlayersListWhenDead(GameObject newPlayer)
    {
        Die newPlayersDie = newPlayer.GetComponent<Die>();
        if (newPlayersDie != null)
            newPlayersDie.OnDying += () =>
            {
                players.Remove(newPlayer.transform);
            };
    }

    private void SetCameraSize()
    {
        float yDistance = (maxPlayersPosition.y - minPlayersPosition.y),
              xDistance = (maxPlayersPosition.x - minPlayersPosition.x);
        float maxDistance = Mathf.Max(yDistance, xDistance * Screen.height / Screen.width);
        this.GetComponent<Camera>().orthographicSize = sizeMargin + maxDistance / 2;
    }

    void SetMinMaxPlayersPositons()
    {
        minPlayersPosition = maxPlayersPosition = players[0].position;
        for (int i = 1; i < players.Count; i++)
        {
            if (players[i].position.x > maxPlayersPosition.x) maxPlayersPosition.x = players[i].position.x;
            else if (players[i].position.x < minPlayersPosition.x) minPlayersPosition.x = players[i].position.x;
            if (players[i].position.y > maxPlayersPosition.y) maxPlayersPosition.y = players[i].position.y;
            else if (players[i].position.y < minPlayersPosition.y) minPlayersPosition.y = players[i].position.y;
        }

    }

    // TODO: The method ahead was made using drugs. If you wanna understand it, be sure to use them.
    void MoveTowardsSupposedPosition()
    {
        Vector2 supposedPosition = (minPlayersPosition + maxPlayersPosition) / 2;
        distanceX = supposedPosition.x - this.transform.position.x;
        distanceY = supposedPosition.y - this.transform.position.y;
        isOutOfOffsetX = distanceX > offset1X || distanceX < offset2X;
        isOutOfOffsetY = distanceY > offset1Y || distanceY < offset2Y;
        isOutOfCenterX = distanceX > offset1X / 3.5f || distanceX < offset2X / 3.5f;
        isOutOfCenterY = distanceY > offset1Y / 3.5f || distanceY < offset2Y / 3.5f;
        if (isOutOfOffsetX)
            this.transform.position = new Vector3((distanceX > offset1X)
                                                   ? supposedPosition.x - offset1X
                                                   : supposedPosition.x - offset2X,
                                                  this.transform.position.y,
                                                  this.transform.position.z);
        else if (isOutOfCenterX)
            this.transform.position = new Vector3((distanceX > offset1X / 3.5f)
                                                   ? this.transform.position.x + Time.deltaTime / 3.5f
                                                   : this.transform.position.x - Time.deltaTime / 3.5f,
                                                  this.transform.position.y,
                                                  this.transform.position.z);
        if (isOutOfOffsetY)
            this.transform.position = new Vector3(this.transform.position.x,
                                                  (distanceY > offset1Y)
                                                   ? supposedPosition.y - offset1Y
                                                   : supposedPosition.y - offset2Y,
                                                  this.transform.position.z);
        else if (isOutOfCenterY)
            this.transform.position = new Vector3(this.transform.position.x,
                                                  (distanceY > offset1Y / 3.5f)
                                                   ? this.transform.position.y + Time.deltaTime / 3.5f
                                                   : this.transform.position.y - Time.deltaTime / 3.5f,
                                                  this.transform.position.z);
    }
    void Update()
    {
        SetMinMaxPlayersPositons();
        SetCameraSize();
        MoveTowardsSupposedPosition();
    }
}