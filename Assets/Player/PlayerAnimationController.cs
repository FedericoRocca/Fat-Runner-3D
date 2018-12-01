using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    private Animator myAnimator;
    private PlayerMovement myPlayer;

	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
        myPlayer = GetComponent<PlayerMovement>();
	}

    // Update is called once per frame
    void Update() {

        if (myPlayer.getVelocity() != 0)
        {
            myAnimator.SetBool("Moving", true);
        }
        else
        {
            myAnimator.SetBool("Moving", false);
        }
        
        if (myPlayer.getisGrounded() == true)
        {
            myAnimator.SetBool("isGrounded", true);
        }
        else
        {
            myAnimator.SetBool("isGrounded", false);
        }

    }
}
