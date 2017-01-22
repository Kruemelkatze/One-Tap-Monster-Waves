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

    public AudioClip levelUpSound;
    public AudioClip gameOverSound;

    public AudioClip kniteHitSound;
    public AudioClip mageHitSound;
    public AudioClip portionHPSound;
    public AudioClip potionPoisonSound;
    public AudioClip swordSound;
    public AudioClip shieldSound;
    public AudioClip fireballSound;
    public AudioClip teleportSound;


    public GUIText lvlGUI;
    public GUIText attackGUI;
    public GUIText defenseGUI;
    public GUIText intelligenceGUI;




    public int character;

    private bool move = true;

    bool gameOver = true;


    // Use this for initialization
    void Start()
    {
        transform.position = new Vector2(Grid.World.worldWidth / 2f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        guiUpdate();

        if (hp < 1)
        {
            death();
            if (gameOver) {
                Debug.Log("GameOver Sound Start");
                Grid.SoundManager.PlaySingle(gameOverSound);
                gameOver = false;
            }
            

           
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
            if (character <= 0) {
                Grid.SoundManager.PlaySingle(kniteHitSound);

            } else if (character <= 1) {
                Grid.SoundManager.PlaySingle(mageHitSound);
            } else {
                Grid.SoundManager.PlaySingle(kniteHitSound);
            }

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
        Grid.SoundManager.PlaySingle(gameOverSound);       
        
    }

    private void effectOfPickup(string name)
    {
        if (name.Contains("portionHP"))
        {
            setHp(this.hp + 5);

            Grid.SoundManager.PlaySingle(portionHPSound);
        }
        else if (name.Contains("potionLevelUp"))
        {
            this.lvl += 1;
            Grid.SoundManager.PlaySingle(levelUpSound);
        }
        else if (name.Contains("potionPoison"))
        {
            setHp(this.hp - 5);
            Grid.SoundManager.PlaySingle(potionPoisonSound);
        }
        else if (name.Contains("sword"))
        {
            this.attack += 5;
            Grid.SoundManager.PlaySingle(swordSound);
        }
        else if (name.Contains("shield"))
        {
            this.defense += 5;
            Grid.SoundManager.PlaySingle(shieldSound);
        }
        else if (name.Contains("Fireball"))
        {
            Debug.Log("Fireball");
            fireballActivation();
            Grid.SoundManager.PlaySingle(fireballSound);
        }
        else if (name.Contains("Teleport"))
        {
            teleportActivation();
            Grid.SoundManager.PlaySingle(teleportSound);
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

    void guiUpdate() {
        lvlGUI.text = lvl.ToString();
        attackGUI.text = attack.ToString();
        defenseGUI.text = defense.ToString();
        intelligenceGUI.text = intelligence.ToString();
    }


}





