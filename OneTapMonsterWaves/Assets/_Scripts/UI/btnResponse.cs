using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnResponse : MonoBehaviour {

    public GameObject potion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hoverEffect()
    {
        potion.SetActive(true);
    }

    public void pressedEffect()
    {
        potion.SetActive(true);
    }

    public void exitEffect()
    {
        potion.SetActive(false);
    }
}
