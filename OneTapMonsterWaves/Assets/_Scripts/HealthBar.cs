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
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(healthSlider.maxValue);
        
        if (healthSlider.maxValue != player.lvl * 10) {
            healthSlider.maxValue = player.lvl * 10;
        }

        if (damageSlider.maxValue != player.lvl * 10) {
            damageSlider.maxValue = player.lvl * 10;
        }



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
