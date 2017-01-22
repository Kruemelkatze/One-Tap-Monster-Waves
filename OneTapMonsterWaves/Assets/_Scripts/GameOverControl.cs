using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour
{

    public static int score = -1;
    public GameObject text;
    string fileName = "Assets/score.txt";
    int newScore = 1;

    // Use this for initialization
    void Start()
    {
        //CheckHighscore();
        var t = text.GetComponent<Text>();
        t.text = score < 0 ? "GAME OVER" : "YOU WON! Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckHighscore()
    {

        string line;
        StreamReader theReader = new StreamReader(fileName, Encoding.Default);
        using (theReader)
        {
            line = theReader.ReadLine();

            Debug.Log("HighScore: " + line);
            int actualScore = Int32.Parse(line);

            theReader.Close();
        }
    }

    public void GoToMenu()
    {
        Application.LoadLevel("00-start");
    }
}
