using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfAnimateScript : MonoBehaviour
{
	
	[SerializeField] private Animator myAnimationController;
	
    private void onTriggerEnter(Collider2D other){
		if(other.CompareTag("Player")){
			myAnimationController.SetBool("tail", true);
		}
	}
	
	private void onTriggerExit(Collider2D other){
		if(other.CompareTag("Player")){
			myAnimationController.SetBool("tail", false);
		}
	}
}
