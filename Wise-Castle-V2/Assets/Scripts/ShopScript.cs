/*
ShopScript - functionality of shop;
use points to purchase items, which are flagged as purchased in player inventory
(see InventoryScript)

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
	//set purchase flag
	public void setPurchaseFlag(string id){
		//check if purchased already
		if(PlayerPrefs.GetInt(id, 0) == 1){
			//already purchased
			return;
		}
		//set purchase flag
		PlayerPrefs.SetInt(id, 1);
	}
	
	//buy an item
	public void buyItem(int cost){
		int currentPoints = PlayerPrefs.GetInt("PlayerPoints", 0);
		//check price
		if(cost > currentPoints){
			//cost is too high
			return;
		}
		//take points
		int updatedPoints = currentPoints - cost;
		PlayerPrefs.SetInt("PlayerPoints", updatedPoints);
	}
}
