using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiled2Unity;

public class World : MonoBehaviour
{

    public int worldHeight;
    public int worldWidth;
    public int numOfScreens = 3;

    private BoxCollider2D changeCollider;

    // Use this for initialization
    void Start()
    {
        changeCollider = GetComponent<BoxCollider2D>();

        TiledMap c = (TiledMap)GetComponentInChildren(typeof(TiledMap));
        worldHeight = c.NumTilesHigh;
        worldWidth = c.NumTilesWide;

        MoveMap();
        MoveCollider();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveMap()
    {
        transform.position = new Vector3(transform.position.x, worldHeight, transform.position.z);
    }

    void OnTriggerEnter()
    {

    }

    void MoveCollider()
    {
        var yOffset = -worldHeight + (worldHeight / numOfScreens) * numOfScreens;
        changeCollider.offset = new Vector2(changeCollider.offset.x, yOffset);
    }

}
