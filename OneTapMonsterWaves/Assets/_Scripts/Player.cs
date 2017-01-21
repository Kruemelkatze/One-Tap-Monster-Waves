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

    public void setHp(double hp)
    {
        this.hp = hp;
        healthbar.healthSlider.value = (float)hp;
    }

    public void addHp(double addHp) {
        setHp(hp + addHp);
    }

    public void addIntelligence(double addintelligence) {
        intelligence = intelligence + addintelligence;
    }

    void death()
    {
        //is death
        Grid.EventHub.TriggerPlayerDied();       
        
    }




}





