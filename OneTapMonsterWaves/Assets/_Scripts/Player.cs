using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Actor
{

    public HealthBar healthbar;

    public XpBar xpBar;

    public int difficult = 5;

    public Transform teleportBegin;
    public Transform fireball;

    private bool move = true;


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

        if (Grid.GameManager.playerStarted && move)
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

    public void addHp(double addHp) {
        setHp(hp + addHp);
    }

    public void addIntelligence(float addintelligence) {
        intelligence = intelligence + addintelligence;
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
        else if (name.Contains("potionLevelUp"))
        {
            this.lvl += 1;
        }
        else if (name.Contains("potionPoison"))
        {
            setHp(this.hp - 5);
        }
        else if (name.Contains("sword"))
        {
            this.attack += 5;
        }
        else if (name.Contains("shield"))
        {
            this.defense += 5;
        }
        else if (name.Contains("Fireball"))
        {
            Debug.Log("Fireball");
            fireballActivation();
        }
        else if (name.Contains("Teleport"))
        {
            teleportActivation();
        }
    }

    public void fireballActivation()
    {
        StartCoroutine(StartFireball(2));
    }

    public void teleportActivation()
    {
        //Ask which stage
        int calculatedY = (int)(transform.position.y - intelligence);
        int minY = 3;
        int teleportY = Mathf.Max(minY, calculatedY);
        StartCoroutine(StartTeleport(2, teleportY));
    }

    IEnumerator StartTeleport(float time, int teleportPositionY)
    {
        this.move = false;
        Instantiate(teleportBegin, this.gameObject.transform.position, Quaternion.identity);
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(time);
        this.transform.position = new Vector3(Random.Range(1, 15), 3, 0);
        Instantiate(teleportBegin, this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        this.GetComponent<SpriteRenderer>().enabled = true;
        move = true;
    }

    IEnumerator StartFireball(float time)
    {
        this.move = false;
        Transform existingFireball = Instantiate(fireball, this.gameObject.transform.position, Quaternion.identity);
        float radius = existingFireball.localScale.x + intelligence;
        existingFireball.GetComponent<CircleCollider2D>().radius += (intelligence/10);
        existingFireball.localScale = new Vector3(radius, radius, 0);
        yield return new WaitForSeconds(time);
        move = true;
    }
}





