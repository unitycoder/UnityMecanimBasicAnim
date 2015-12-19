// unitycoder.com

using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	Animator anim;
	int shootTrigger;
	int idleAnimState;

	void Start() 
	{
		// get reference to Animator component
		anim = GetComponent<Animator>();

		// "Shoot" is name of the trigger in Animator window Parameters tab
		shootTrigger = Animator.StringToHash("Shoot");
		idleAnimState = Animator.StringToHash ("player_idle_right");
	}

	// main loop
	void Update() 
	{
	
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			// check if trigger is currently off, cannot shoot if already shooting
			AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
			if (stateInfo.shortNameHash == idleAnimState) // not working
			{
				Debug.Log ("ShootTrigger");

				// triggers "Shoot" parameter to true
				anim.SetTrigger(shootTrigger);
				// animator then transitions to "player_shoot_right"-anim
				// plays it once and returns to "player_idle_right"-anim
			}
		}
	}

	// this event gets called from Animation timeline
	public void ShootEvent()
	{
		Debug.Log ("ShootEvent called");
	}
}
