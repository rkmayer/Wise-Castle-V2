using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	
	public float playerSpeed = 150;
	
    // Update is called once per frame
    void Update()
    {
		
		//player moves right automatically
		transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        
    }
	
	//player (this) collides with object (other)
	private void OnTriggerEnter2D(Collider2D other){
		playerSpeed = playerSpeed * -1;
	}
}
