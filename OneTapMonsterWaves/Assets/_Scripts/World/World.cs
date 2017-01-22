using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiled2Unity;

public class World : MonoBehaviour
{

    public float worldHeight;
    public float worldWidth;
    public int numOfScreens = 3;
    public int currentScreen = 0;

    private BoxCollider2D changeCollider;
    private Vector2 defaultColliderOffset;

    // Use this for initialization
    void Awake()
    {
        changeCollider = GetComponent<BoxCollider2D>();
        defaultColliderOffset = changeCollider.offset;

        TiledMap c = (TiledMap)GetComponentInChildren(typeof(TiledMap));
        if (c != null)
        {
            worldHeight = c.NumTilesHigh;
            worldWidth = c.NumTilesWide;
        }
        else
        {
            worldHeight *= transform.localScale.y;
            worldWidth *= transform.localScale.x;
        }
    }

    void Start()
    {
        //MoveMapToOrigin();
        //MoveCollider();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveMapToOrigin()
    {
        transform.position = new Vector3(transform.position.x, worldHeight, transform.position.z);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Grid.Player.MoveToMiddle = false;

            if (currentScreen < 2 && !Grid.GameManager.TeleportActive)
            {
                currentScreen++;
                MoveCollider();
                Grid.EventHub.TriggerPlayerReachedTopEvent(currentScreen);
            }
            // else
            // {
            //     Grid.EventHub.TriggerGameWon();
            // }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Grid.Player.MoveToMiddle = true;
        }
    }

    void MoveCollider()
    {
        Debug.Log("Before: " + changeCollider.offset.y);
        var yOffset = (worldHeight / numOfScreens + 0.5f) * currentScreen + defaultColliderOffset.y;
        
        changeCollider.offset = new Vector2(changeCollider.offset.x, yOffset);
        Debug.Log("After: " + changeCollider.offset.y);

    }

    public float GetCurrentWorldBase() {
        return (worldHeight / numOfScreens) * currentScreen;
    }

}
