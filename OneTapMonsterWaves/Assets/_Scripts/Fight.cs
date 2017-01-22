using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    //basic stats
    public Player player;
    public Enemy enemy;

    bool fight = true;
    bool playerturn = true;

    public void fighting()
    {
        while (fight)
        {


            //     //player and enemy stats output (temp)
            //     Debug.Log("Player");
            //     Debug.Log("LVL: " + player.lvl);
            //     Debug.Log("HP: " + player.hp);
            // Debug.Log("ATK: " + player.attack);
            // Debug.Log("DEF: " + player.defense);
            //     Debug.Log("INT: " + player.intelligence);
            //     Debug.Log(" ");
            //     Debug.Log("Enemy");
            //     Debug.Log("LVL: " + enemy.lvl);
            //     Debug.Log("HP: " + enemy.hp);
            // Debug.Log("ATK: " + enemy.attack);
            // Debug.Log("DEF: " + enemy.defense);
            //     Debug.Log(" ");



            //great random number from 3 times 6(random)
            int randomNumber = Random.Range(1, 6) + Random.Range(1, 6) + Random.Range(1, 6);
            //Debug.Log("Random Nr.: " + randomNumber);

            //fight
            if (playerturn)
            {

                double result = ((player.attack + player.lvl) - (enemy.defense + enemy.lvl)) + randomNumber;
                //Debug.Log("Result: " + result);
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

                double result = ((enemy.attack + enemy.lvl) - (player.defense + player.lvl)) + randomNumber;
                //Debug.Log("Result: " + result);
                if (result > 0)
                {

                    player.setHp(player.hp - result);

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
                this.fight = false;
                player.xpBar.getXp(enemy.derivedXP);
                Debug.Log(enemy.gameObject.name + " died. Player: " + player.hp + ", " + player.xp);
            }

            //look if player is death
            if (player.hp < 1)
            {
                this.fight = false;
                Debug.Log("Player died. Player: " + player.hp + ", " + player.xp + "; Enemy:" + enemy.gameObject.name);
                

            }


            //player and enemy stats output (temp)

            // Debug.Log("Player");
            // Debug.Log("LVL: " + player.lvl);
            // Debug.Log("HP: " + player.hp);
            // Debug.Log("DEF: " + player.defense);
            // Debug.Log("INT: " + player.intelligence);
            // Debug.Log(" ");
            // Debug.Log("Enemy");
            // Debug.Log("LVL: " + enemy.lvl);
            // Debug.Log("HP: " + enemy.hp);
            // Debug.Log("DEF: " + enemy.defense);
            // Debug.Log(" ");
        }

    }
    IEnumerator waitingInSec(int time)
    {
        yield return new WaitForSeconds(time);
    }


}
