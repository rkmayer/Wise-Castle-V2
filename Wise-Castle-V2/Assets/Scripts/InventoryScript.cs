/*
InventoryScript - uses playerprefs to store the player's purchased items;
player can access all *purchased* items and equip them to their character whenever they wish

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
	//inventory buttons
	[SerializeField] Button Hat1_1, Hat1_2, Hat1_3, Hat1_4, Hat1_5, Hat1_6, Hat1_7, Hat1_8,
							Hat2_1, Hat2_2, Hat2_3, Hat2_4, Hat2_5, Hat2_6, Hat2_7, Hat2_8,
							Hat3_1, Hat3_2, Hat3_3, Hat3_4, Hat3_5, Hat3_6, Hat3_7, Hat3_8,
							Robe1_1, Robe1_2, Robe1_3, Robe1_4, Robe1_5, Robe1_6,
							Robe2_1, Robe2_2, Robe2_3, Robe2_4, Robe2_5, Robe2_6,
							Robe3_1, Robe3_2, Robe3_3, Robe3_4, Robe3_5, Robe3_6;

    void Start(){
		//playerprefs used to store inventory
		//hats - hat 1
		int hat1_1 = PlayerPrefs.GetInt("hat1_1", 0);
		int hat1_2 = PlayerPrefs.GetInt("hat1_2", 0);
		int hat1_3 = PlayerPrefs.GetInt("hat1_3", 0);
		int hat1_4 = PlayerPrefs.GetInt("hat1_4", 0);
		int hat1_5 = PlayerPrefs.GetInt("hat1_5", 0);
		int hat1_6 = PlayerPrefs.GetInt("hat1_6", 0);
		int hat1_7 = PlayerPrefs.GetInt("hat1_7", 0);
		int hat1_8 = PlayerPrefs.GetInt("hat1_8", 0);
		//hats - hat 2
		int hat2_1 = PlayerPrefs.GetInt("hat2_1", 0);
		int hat2_2 = PlayerPrefs.GetInt("hat2_2", 0);
		int hat2_3 = PlayerPrefs.GetInt("hat2_3", 0);
		int hat2_4 = PlayerPrefs.GetInt("hat2_4", 0);
		int hat2_5 = PlayerPrefs.GetInt("hat2_5", 0);
		int hat2_6 = PlayerPrefs.GetInt("hat2_6", 0);
		int hat2_7 = PlayerPrefs.GetInt("hat2_7", 0);
		int hat2_8 = PlayerPrefs.GetInt("hat2_8", 0);
		//hats - hats 3
		int hat3_1 = PlayerPrefs.GetInt("hat3_1", 0);
		int hat3_2 = PlayerPrefs.GetInt("hat3_2", 0);
		int hat3_3 = PlayerPrefs.GetInt("hat3_3", 0);
		int hat3_4 = PlayerPrefs.GetInt("hat3_4", 0);
		int hat3_5 = PlayerPrefs.GetInt("hat3_5", 0);
		int hat3_6 = PlayerPrefs.GetInt("hat3_6", 0);
		int hat3_7 = PlayerPrefs.GetInt("hat3_7", 0);
		int hat3_8 = PlayerPrefs.GetInt("hat3_8", 0);
		
		//robes - robes 1
		int robe1_1 = PlayerPrefs.GetInt("robe1_1", 0);
		int robe1_2 = PlayerPrefs.GetInt("robe1_2", 0);
		int robe1_3 = PlayerPrefs.GetInt("robe1_3", 0);
		int robe1_4 = PlayerPrefs.GetInt("robe1_4", 0);
		int robe1_5 = PlayerPrefs.GetInt("robe1_5", 0);
		int robe1_6 = PlayerPrefs.GetInt("robe1_6", 0);
		//robes - robes 2
		int robe2_1 = PlayerPrefs.GetInt("robe2_1", 0);
		int robe2_2 = PlayerPrefs.GetInt("robe2_2", 0);
		int robe2_3 = PlayerPrefs.GetInt("robe2_3", 0);
		int robe2_4 = PlayerPrefs.GetInt("robe2_4", 0);
		int robe2_5 = PlayerPrefs.GetInt("robe2_5", 0);
		int robe2_6 = PlayerPrefs.GetInt("robe2_6", 0);
		//robes - robes 3
		int robe3_1 = PlayerPrefs.GetInt("robe3_1", 0);
		int robe3_2 = PlayerPrefs.GetInt("robe3_2", 0);
		int robe3_3 = PlayerPrefs.GetInt("robe3_3", 0);
		int robe3_4 = PlayerPrefs.GetInt("robe3_4", 0);
		int robe3_5 = PlayerPrefs.GetInt("robe3_5", 0);
		int robe3_6 = PlayerPrefs.GetInt("robe3_6", 0);
	
        //check hats
		if(hat1_1 == 1){
			//is purchased
			Hat1_1.interactable = true;
		}else{
			//is not purchased
			Hat1_1.interactable = false;
		}
		
		if(hat1_2 == 1){
			//is purchased
			Hat1_2.interactable = true;
		}else{
			//is not purchased
			Hat1_2.interactable = false;
		}
		
		if(hat1_3 == 1){
			//is purchased
			Hat1_3.interactable = true;
		}else{
			//is not purchased
			Hat1_3.interactable = false;
		}
		
		if(hat1_4 == 1){
			//is purchased
			Hat1_4.interactable = true;
		}else{
			//is not purchased
			Hat1_4.interactable = false;
		}
		
		if(hat1_5 == 1){
			//is purchased
			Hat1_5.interactable = true;
		}else{
			//is not purchased
			Hat1_5.interactable = false;
		}
		
		if(hat1_6 == 1){
			//is purchased
			Hat1_6.interactable = true;
		}else{
			//is not purchased
			Hat1_6.interactable = false;
		}
		
		if(hat1_7 == 1){
			//is purchased
			Hat1_7.interactable = true;
		}else{
			//is not purchased
			Hat1_7.interactable = false;
		}
		
		if(hat1_8 == 1){
			//is purchased
			Hat1_8.interactable = true;
		}else{
			//is not purchased
			Hat1_8.interactable = false;
		}
		
		if(hat2_1 == 1){
			//is purchased
			Hat2_1.interactable = true;
		}else{
			//is not purchased
			Hat2_1.interactable = false;
		}
		
		if(hat2_2 == 1){
			//is purchased
			Hat2_2.interactable = true;
		}else{
			//is not purchased
			Hat2_2.interactable = false;
		}
		
		if(hat2_3 == 1){
			//is purchased
			Hat2_3.interactable = true;
		}else{
			//is not purchased
			Hat2_3.interactable = false;
		}
		
		if(hat2_4 == 1){
			//is purchased
			Hat2_4.interactable = true;
		}else{
			//is not purchased
			Hat2_4.interactable = false;
		}
		
		if(hat2_5 == 1){
			//is purchased
			Hat2_5.interactable = true;
		}else{
			//is not purchased
			Hat2_5.interactable = false;
		}
		
		if(hat2_6 == 1){
			//is purchased
			Hat2_6.interactable = true;
		}else{
			//is not purchased
			Hat2_6.interactable = false;
		}
		
		if(hat2_7 == 1){
			//is purchased
			Hat2_7.interactable = true;
		}else{
			//is not purchased
			Hat2_7.interactable = false;
		}
		
		if(hat2_8 == 1){
			//is purchased
			Hat2_8.interactable = true;
		}else{
			//is not purchased
			Hat2_8.interactable = false;
		}
		
		if(hat3_1 == 1){
			//is purchased
			Hat3_1.interactable = true;
		}else{
			//is not purchased
			Hat3_1.interactable = false;
		}
		
		if(hat3_2 == 1){
			//is purchased
			Hat3_2.interactable = true;
		}else{
			//is not purchased
			Hat3_2.interactable = false;
		}
		
		if(hat3_3 == 1){
			//is purchased
			Hat3_3.interactable = true;
		}else{
			//is not purchased
			Hat3_3.interactable = false;
		}
		
		if(hat3_4 == 1){
			//is purchased
			Hat3_4.interactable = true;
		}else{
			//is not purchased
			Hat3_4.interactable = false;
		}
		
		if(hat3_5 == 1){
			//is purchased
			Hat3_5.interactable = true;
		}else{
			//is not purchased
			Hat3_5.interactable = false;
		}
		
		if(hat3_6 == 1){
			//is purchased
			Hat3_6.interactable = true;
		}else{
			//is not purchased
			Hat3_6.interactable = false;
		}
		
		if(hat3_7 == 1){
			//is purchased
			Hat3_7.interactable = true;
		}else{
			//is not purchased
			Hat3_7.interactable = false;
		}
		
		if(hat3_8 == 1){
			//is purchased
			Hat3_8.interactable = true;
		}else{
			//is not purchased
			Hat3_8.interactable = false;
		}
    }
}
