using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //basic stats
    public int lvl = 1;

    public double att = 10;
    public double hp = 10;
    public double def = 10;
    public double intel = 10;

    bool fight = false;
    bool playerturn = true;

    Enemy enemy;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (fight)
        {
            fighting();
        }




    }

    //if something hit the player
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {

            enemy = other.GetComponent<Enemy>();
            playerturn = true;
            fight = true;



        }



    }

    IEnumerator waitingInSec(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void fighting(){ //temp waiting
        waitingInSec(2);

        //player and enemy stats output (temp)
        Debug.Log("Player");
        Debug.Log("LVL: " + lvl);
        Debug.Log("HP: " + hp);
        Debug.Log("DEF: " + def);
        Debug.Log("INT: " + intel);
        Debug.Log(" ");
        Debug.Log("Enemy");
        Debug.Log("LVL: " + enemy.lvl);
        Debug.Log("HP: " + enemy.hp);
        Debug.Log("DEF: " + enemy.def);
        Debug.Log(" ");



        //great random number from 3 times 6(random)
        int randomNumber = Random.Range(1, 6) + Random.Range(1, 6) + Random.Range(1, 6);

        //fight
        if (playerturn)
        {

            double result = ((att + lvl) - (enemy.def + enemy.lvl)) - randomNumber;

            if (result > 0)
            {
                enemy.hp = enemy.hp - result;

            }
            else
            {

                //missed

            }
            playerturn = false;

        }
        else
        {

            double result = ((enemy.att + enemy.lvl) - (def + lvl)) - randomNumber;

            if (result > 0)
            {
                enemy.hp = enemy.hp - result;

            }
            else
            {

                //missed

            }

            playerturn = true;
        }






        //look if enemy is death
        if (enemy.hp < 1)
        {
            fight = false;
        }

        //look if player is death
        if (hp < 1)
        {
            fight = false;
        }









        //player and enemy stats output (temp)

        Debug.Log("Player");
        Debug.Log("LVL: " + lvl);
        Debug.Log("HP: " + hp);
        Debug.Log("DEF: " + def);
        Debug.Log("INT: " + intel);
        Debug.Log(" ");
        Debug.Log("Enemy");
        Debug.Log("LVL: " + enemy.lvl);
        Debug.Log("HP: " + enemy.hp);
        Debug.Log("DEF: " + enemy.def);
        Debug.Log(" ");
    }

}





