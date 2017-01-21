using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiled2Unity;

public class World : MonoBehaviour
{

    public int worldHeight;
    public int worldWidth;
    public int numOfScreens = 3;
    public int currentScreen = 0;

    private BoxCollider2D changeCollider;

    // Use this for initialization
    void Start()
    {
        changeCollider = GetComponent<BoxCollider2D>();

        TiledMap c = (TiledMap)GetComponentInChildren(typeof(TiledMap));
        worldHeight = c.NumTilesHigh;
        worldWidth = c.NumTilesWide;

        MoveMapToOrigin();
        MoveCollider();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveMapToOrigin()
    {
        transform.position = new Vector3(transform.position.x, worldHeight, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentScreen++;
            MoveCollider();
            Grid.EventHub.TriggerPlayerReachedTopEvent(currentScreen);
        }
    }

    void MoveCollider()
    {
        var yOffset = -this.worldHeight + (worldHeight / numOfScreens) * (currentScreen + 1);
        changeCollider.offset = new Vector2(changeCollider.offset.x, yOffset);
    }

}
