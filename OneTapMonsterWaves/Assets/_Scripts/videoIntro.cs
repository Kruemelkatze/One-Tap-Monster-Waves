using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoIntro : MonoBehaviour {

    RectTransform rt;
    Vector2 origPos;

    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        rt = GetComponent<RectTransform>();
        origPos = rt.anchoredPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
