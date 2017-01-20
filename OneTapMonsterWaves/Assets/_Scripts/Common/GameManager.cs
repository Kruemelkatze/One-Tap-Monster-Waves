using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerStarted = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPlayer(float worldPosX)
    {
        if (playerStarted)
            return;

        playerStarted = true;
        Grid.Player.transform.position = new Vector2(worldPosX, Grid.Player.transform.position.y);
    }
}
