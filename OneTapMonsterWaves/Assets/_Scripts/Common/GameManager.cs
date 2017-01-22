using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerStarted = false;
    public float playerOffsetBottom = 1;
    public bool TeleportActive = false;


    // Use this for initialization
    void Start()
    {
        Grid.EventHub.PlayerDied += PlayerDied;
        Grid.EventHub.GameWon += GameWon;

        Grid.SoundManager.PlayMusic(Grid.SoundManager.ActionTheme);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Destroy()
    {
        Grid.EventHub.PlayerDied -= PlayerDied;
        Grid.EventHub.GameWon -= GameWon;
    }

    void PlayerDied()
    {
        this.playerStarted = false;
        //Grid.LevelManager.loadLevel()
    }

    void GameWon()
    {
        Debug.Log("WON");
        this.playerStarted = false;
    }

    public void StartPlayer(float worldPosX)
    {
        if (playerStarted)
            return;

        playerStarted = true;
        Grid.Player.StartPlayer(worldPosX);
    }
}
