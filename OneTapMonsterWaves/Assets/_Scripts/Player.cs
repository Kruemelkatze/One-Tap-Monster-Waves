using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 2f;

    //basic stats
    public int lvl = 1;

    public double att = 10;
    public double hp = 10;
    public double def = 10;
    public double intel = 10;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector2(Grid.World.worldWidth / 2f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Grid.GameManager.playerStarted)
        {
            //Moving
            float f = Time.deltaTime;
            float newY = transform.position.y + f * playerSpeed;
            transform.position = new Vector2(transform.position.x, newY);
        }
    }

    //if something hit the player
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {

            Enemy enemy = other.GetComponent<Enemy>();
            Fight fight = new Fight();

            fight.enemy = enemy;
            fight.player = this;
            fight.fighting();




        }



    }

    IEnumerator waitingInSec(float time)
    {
        yield return new WaitForSeconds(time);
    }



}





