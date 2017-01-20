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





    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        




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





