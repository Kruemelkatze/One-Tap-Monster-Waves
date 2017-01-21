using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour {

    public Player player;
    public Slider xpSlider;

    // Use this for initialization
    void Start () {
        player.xpBar = this;
    }
	
	// Update is called once per frame
	void Update () {
        
		
	}
    
    public void getXp(double xp) {
        if (xpSlider.value + (float)xp >= xpSlider.maxValue) {

            
            bool levelUp = true;
            while (levelUp) {
                double levelUpXp = (xpSlider.value + (float) xp) - xpSlider.maxValue;

                player.lvl++;

                //calculate XP for the next level up
                int nextLevelXp = 0;
                for (int i = 0; i < player.lvl + 1; i++) {
                    nextLevelXp += player.difficult * i;
                }

                //set XP and Health Bar
                xpSlider.maxValue = nextLevelXp;
                player.healthbar.healthSlider.maxValue = player.lvl * 10;
                player.healthbar.healthSlider.value = player.lvl * 10;
                player.healthbar.damageSlider.maxValue = player.lvl * 10;
                player.healthbar.damageSlider.value = player.lvl * 10;

                // look if XP is more as one level up
                if (xpSlider.value + (float)levelUpXp < xpSlider.maxValue) {
                    levelUp = false;
                }
            }
            player.xp = xpSlider.value;

        } else {
            xpSlider.value = xpSlider.value + (float) xp;
            player.xp = player.xp + xp;
        }
    }


}
