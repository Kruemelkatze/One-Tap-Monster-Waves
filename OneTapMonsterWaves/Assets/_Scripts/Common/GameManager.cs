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
        GameOverControl.score = -1;
        Invoke("MoveAway", 3);

        //Grid.LevelManager.loadLevel()
    }

    void GameWon()
    {
        Debug.Log("WON");
        this.playerStarted = false;
        GameOverControl.score = (int)(Grid.Player.xp * 10);
        Invoke("MoveAway", 3);
    }

    void MoveAway()
    {
        Application.LoadLevel(4);
    }

    public void StartPlayer(float worldPosX)
    {
        if (playerStarted || worldPosX < 0 || worldPosX > Grid.World.worldWidth)
            return;

        playerStarted = true;
        Grid.Player.StartPlayer(worldPosX);
    }
}
