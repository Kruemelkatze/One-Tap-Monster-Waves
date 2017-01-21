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
    {
        int loopounter = 0;
        while (fight)
        {
            loopounter++;


            //player and enemy stats output (temp)
            Debug.Log("        LVL/HP/ATK/DEF/INT ");
            Debug.Log("Player: " + player.lvl + "/" + player.hp + "/" + player.attack + "/" + player.defense + "/" + player.intelligence);
            Debug.Log("Enemy" + enemy.lvl + "/" + enemy.hp + "/" + enemy.attack + "/" + enemy.defense + "/" + enemy.intelligence);



            //great random number from 3 times 6(random)
            int randomNumber = Random.Range(1, 6) + Random.Range(1, 6) + Random.Range(1, 6);
        Debug.Log("Random Nr.: " + randomNumber);

        //fight
        if (playerturn)
            {

                double result = ((player.attack + player.lvl) - (enemy.defense + enemy.lvl)) + randomNumber;
            Debug.Log("Result: " + result);
            if (result > 0){
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
            Debug.Log("Result: " + result);
            if (result > 0){

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
                
            }
            
            //look if player is death
            if (player.hp < 1)
            {
                this.fight = false;
            }


            //player and enemy stats output (temp)

            Debug.Log("        LVL/HP/ATK/DEF/INT ");
            Debug.Log("Player: " + player.lvl + "/" + player.hp + "/" + player.attack + "/" + player.defense + "/" + player.intelligence);
            Debug.Log("Enemy" + enemy.lvl + "/" + enemy.hp + "/" + enemy.attack + "/" + enemy.defense + "/" + enemy.intelligence);

            

        }
       
        Debug.Log("The fight had " + loopounter + " Rounds.");
        

    }
        IEnumerator waitingInSec(int time){
            yield return new WaitForSeconds(time);
        }
    

}
