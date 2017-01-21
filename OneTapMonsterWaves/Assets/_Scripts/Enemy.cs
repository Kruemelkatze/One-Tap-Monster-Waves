using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{

    public double derivedXP;

    private bool left;
    private bool fight;
    private Vector3 vec3Movement;

    public int attackFrom = 1;
    public int attackTo = 1;
    public int defenseFrom = 0;
    public int defenseTo = 1;

    // Use this for initialization
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            left = false;
        }
        else
        {
            left = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            dead();
        }
        else
        {
            if (!fight)
            {
                move();
            }
        }
    }

    public void DeriveValues(int level)
    {
        this.lvl = level;
        this.hp = level * 10;
        this.attack = Random.Range(attackFrom, attackTo);
        this.defense = Random.Range(defenseFrom, defenseTo);
        this.derivedXP = level;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle")
        {
            left = !left;
        }
        if (col.tag == "Player")
        {
            fight = true;
        }
        if (col.tag == "Fireball")
        {
            dead();
        }
    }

    void move()
    {
        if (left)
        {
            vec3Movement = Vector3.left * movement * Time.deltaTime;
        }
        else
        {
            vec3Movement = Vector3.right * movement * Time.deltaTime;
        }
        transform.Translate(vec3Movement);
    }


    IEnumerator dead()
    {
<<<<<<< Updated upstream
        yield return new WaitForSeconds(3);
=======
        yield return new WaitForSeconds(2);
>>>>>>> Stashed changes
        Destroy(gameObject);
    }

}
