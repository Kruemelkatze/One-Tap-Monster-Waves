using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Player player;
    public Slider healthSlider;
    public Slider damageSlider;

    public int waitBetweenDamageDown = 2;
    int countAfterHitBar;

    bool damage;

	// Use this for initialization
	void Start () {
        player.healthbar = this;
		
	}
	
	// Update is called once per frame
	void Update () {
        
        // healthBar red background delay
        if (damageSlider.value > healthSlider.value) {
            if (countAfterHitBar >= waitBetweenDamageDown) {
                countAfterHitBar = -1;
                damageSlider.value--;
            }
            countAfterHitBar++;
        } else if (damageSlider.value < healthSlider.value) {
            damageSlider.value = healthSlider.value;
        } else {
            countAfterHitBar = 0;
        }

        damage = false;
		
	}

    void getDamage(float damageTaken) {
        damage = true;

        healthSlider.value = healthSlider.value - damageTaken;


    }


}
