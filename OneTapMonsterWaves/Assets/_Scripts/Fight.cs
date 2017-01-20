using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour {

    
    //basic stats
    public Player player;
    public Enemy enemy;

    bool fight = true;
    bool playerturn = true;

    




    

    public void fighting()
    { //temp waiting
        while (fight)
        {
            waitingInSec(2);

            //player and enemy stats output (temp)
            Debug.Log("Player");
            Debug.Log("LVL: " + player.lvl);
            Debug.Log("HP: " + player.hp);
            Debug.Log("DEF: " + player.def);
            Debug.Log("INT: " + player.intel);
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

                double result = ((player.att + player.lvl) - (enemy.def + enemy.lvl)) - randomNumber;

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

                double result = ((enemy.att + enemy.lvl) - (player.def + player.lvl)) - randomNumber;

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
            if (player.hp < 1)
            {
                fight = false;
            }


            //player and enemy stats output (temp)

            Debug.Log("Player");
            Debug.Log("LVL: " + player.lvl);
            Debug.Log("HP: " + player.hp);
            Debug.Log("DEF: " + player.def);
            Debug.Log("INT: " + player.intel);
            Debug.Log(" ");
            Debug.Log("Enemy");
            Debug.Log("LVL: " + enemy.lvl);
            Debug.Log("HP: " + enemy.hp);
            Debug.Log("DEF: " + enemy.def);
            Debug.Log(" ");
        }

    }
        IEnumerator waitingInSec(float time){
            yield return new WaitForSeconds(time);
        }
    

}
