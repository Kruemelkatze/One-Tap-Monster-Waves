using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceAnmation : MonoBehaviour {

    public Animator animator;
    RuntimeAnimatorController ac;

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
            
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("AnimationPlaying: " + animator.GetCurrentAnimatorStateInfo(0).IsName("TeleportBegin"));
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("TeleportBegin"))
        {
            Destroy(gameObject);
        }
	}

    
}
