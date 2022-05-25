using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class cameraFollow : MonoBehaviour
{
    private Vector3 supposedPosition;
    public float offset1X = 0.35f, offset1Y = -0.35f, offset2X = -0.35f, offset2Y = -0.75f;
    float distanceX, distanceY;
    bool isOutOfOffsetX, isOutOfOffsetY, isOutOfCenterX, isOutOfCenterY;
    private List<Transform> players = new List<Transform>();
    private void Awake()
    {
        PlayerInstantiator.OnInstantiatePlayer += (GameObject newPlayer, int playerNumber) =>
        {
            players.Insert(playerNumber, newPlayer.transform);
        };
    }
    private void SetCameraSize()
    {
        float maxDistanceX = 0, maxDistanceY = 0;
        for (int i = 0; i < players.Count; i++)
            for (int j = 0; j < players.Count; j++)
            {
                float dX = Mathf.Abs(players[i].position.x - players[j].position.x),
                      dY = Mathf.Abs(players[i].position.y - players[j].position.y);
                if (dX > maxDistanceX) maxDistanceX = dX;
                if (dY > maxDistanceY) maxDistanceY = dY;
            }
        // The numbers you see ahead have come from God; don't question them.
        float minWidth = 4 + maxDistanceX, minHight = 4 + maxDistanceY;
        if (minHight < minWidth * 2 / 5) minHight = minWidth * 2 / 5;
        if (minWidth < minHight * 5 / 2) minWidth = minHight * 5 / 2;
        this.GetComponent<Camera>().orthographicSize = minWidth / 5 + 2;
    }

    void SetSupposedPositon()
    {
        float newX = 0, newY = 0;
        for (int i = 0; i < players.Count; i++)
        {
            newX += players[i].position.x;
            newY += players[i].position.y;
        }
        newX /= players.Count;
        newY /= players.Count;
        supposedPosition = new Vector3(newX, newY, this.transform.position.z);
    }

    // The method ahead was made using drugs. If you wanna understand it, be sure to use them.
    void MoveTowardsSupposedPosition()
    {
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
        SetCameraSize();
        SetSupposedPositon();
        MoveTowardsSupposedPosition();
    }
}