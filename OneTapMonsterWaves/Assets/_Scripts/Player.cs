using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Actor
{

    public HealthBar healthbar;

    public XpBar xpBar;

    public int difficult = 5;



    // Use this for initialization
    void Start()
    {

        transform.position = new Vector2(Grid.World.worldWidth / 2f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 1)
        {
            death();
        }

        if (Grid.GameManager.playerStarted)
        {
            //Moving
            float f = Time.deltaTime;
            float newY = transform.position.y + f * movement;
            transform.position = new Vector2(transform.position.x, newY);
        }
    }

    //if something hit the player

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tag: "+other.tag);
        if (other.tag == "Enemy")
        {


            Enemy enemy = other.GetComponent<Enemy>();
            Fight fight = new Fight();

            fight.enemy = enemy;
            fight.player = this;
            fight.fighting();
        }
        if(other.tag == "PickUp")
        {
            effectOfPickup(other.name);
            Destroy(other.gameObject);
        }
    }

    IEnumerator waitingInSec(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public void setHp(double hp)
    {
        this.hp = hp;
        healthbar.healthSlider.value = (float)hp;
    }

    void death()
    {
        //is death
        Grid.EventHub.TriggerPlayerDied();       
        
    }

    private void effectOfPickup(string name)
    {
        if (name.Contains("portionHP"))
        {
            setHp(this.hp + 5);
        }
    }




}





