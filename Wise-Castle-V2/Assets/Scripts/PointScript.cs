/*
Point Script - for saving/loading player points between sessions,
and updating the amount of points (after a game, after a purchase)

Ryan Mayer

*/
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour{
	
	//points shown in player info
	public Text playerInfoPoints;
	
	//runs before everything else
	void Start(){
		//load points
		playerInfoPoints.text = PlayerPrefs.GetInt("PlayerPoints", 0).ToString();
	}
	
	//subtract from player points p amount
	public void SubtractPoints(int p){
		int currentPoints = PlayerPrefs.GetInt("PlayerPoints", 0);
		int updatedPoints = currentPoints - p;
		PlayerPrefs.SetInt("PlayerPoints", updatedPoints);
	}
	
	//add to player points p amount
	public void AddPoints(int p){
		int currentPoints = PlayerPrefs.GetInt("PlayerPoints", 0);
		int updatedPoints = currentPoints + p;
		PlayerPrefs.SetInt("PlayerPoints", updatedPoints);
	}
	
	//set player points to 0
	public void ZeroPoints(){
		PlayerPrefs.SetInt("PlayerPoints", 0);
		playerInfoPoints.text = PlayerPrefs.GetInt("PlayerPoints", 0).ToString();
	}
}
