using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadLevel(int levelnr)
    {
        if (levelnr == 0)
        {
            Application.LoadLevel("00-start");
        }
        else if (levelnr == 1)
        {
            Application.LoadLevel("01-startscreen");
        }
        else if (levelnr == 2)
        {
            Application.LoadLevel("02-menu");
        }
        else if (levelnr == 3)
        {
            Application.LoadLevel("03-level");
        }
    }

    void loadNewGame()
    {

    }
}
