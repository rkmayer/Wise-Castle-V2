using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	
	public float playerSpeed = 150;
	
	public bool stopped = false;
	
	bool questionPassed = false;
	
    // Update is called once per frame
    void Update()
    {
		if(!stopped){
			//player moves right automatically
			transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
		}
        
    }
	
	//player (this) collides with object (other)
	public void OnTriggerEnter2D(Collider2D other){
		//stop player
		stopped = true;
		//show math question

		//after question is passed...
		if(questionPassed){
			//award points(?)
			//delete object
			if(other.gameObject.tag == "delete"){
				Destroy(other.gameObject);
				stopped = false;
			}
		}
	}
}
