using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int screenHeight = Screen.height;
            Vector3 mousePosition = Input.mousePosition;
            float worldPosX = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y)).x;
            Grid.GameManager.StartPlayer(worldPosX);

        }
    }
}
