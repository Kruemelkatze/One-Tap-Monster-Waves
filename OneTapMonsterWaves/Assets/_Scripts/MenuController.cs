using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject gameOverScreen;
    public GameObject newGameScreen;
    public GameObject startScreen;
    public GameObject optionScreen;
    public GameObject loadingScreen;
    public GameObject creditsScreen;
    public GameObject introScreen;
    public MovieTexture introVideo;

    // Use this for initialization
    void Start () {
        StartCoroutine(LoadingScreenWait(5));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadingScreenWait(float time)
    {
        yield return new WaitForSeconds(time);
        loadingScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void GoToNewGameScreen()
    {
        startScreen.SetActive(false);
        newGameScreen.SetActive(true);
    }

    public void GoToCredits()
    {
        startScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void GoToStartscreen()
    {
        newGameScreen.SetActive(false);
        creditsScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void StartIntro()
    {
        newGameScreen.SetActive(false);
        Grid.LevelManager.loadLevel(3);
        //introScreen.SetActive(true);
        //Handheld.PlayFullScreenMovie("video/intro_video.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }
}
