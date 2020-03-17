/*
CharacterScript allows player to edit their character;
playerprefs used to save item IDs for slots (body, eyes, mouth, hair, clothes, hat, animal)

Ryan Mayer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
	//combine to show selected sprites as a full character
	[SerializeField] GameObject PlayerBody, PlayerEyes, PlayerMouth, PlayerHair, PlayerClothes, PlayerHat, PlayerAnimal;
	
	//sprites
	//body
	[SerializeField] Sprite Body1, Body2, Body3, Body4, Body5;
	//clothes
	[SerializeField] Sprite Robe1Red, Robe1Blue, Robe1Green, Robe1Grey, Robe1Orange, Robe1Purple,
							Robe2Red, Robe2Blue, Robe2Green, Robe2Grey, Robe2Orange, Robe2Purple,
							Robe3Red, Robe3Blue, Robe3Green, Robe3Grey, Robe3Orange, Robe3Purple,
							Clothes1;
	//eyes
	[SerializeField] Sprite Eyes1, Eyes2, Eyes3, Eyes4;
	//hair
	[SerializeField] Sprite Hair1;
	//hats
	[SerializeField] Sprite Hat1;
	//mouths
	[SerializeField] Sprite Mouth1, Mouth2;
	//animals
	[SerializeField] Sprite Bunny, Turtle;
	
	public void Start(){
		//get spriterenderer components of each character part
		//(use these .sprite attributes to set sprites)
		SpriteRenderer BodySprite = PlayerBody.GetComponent<SpriteRenderer>();
		SpriteRenderer EyesSprite = PlayerEyes.GetComponent<SpriteRenderer>();
		SpriteRenderer MouthSprite = PlayerMouth.GetComponent<SpriteRenderer>();
		SpriteRenderer HairSprite = PlayerHair.GetComponent<SpriteRenderer>();
		SpriteRenderer ClothesSprite = PlayerClothes.GetComponent<SpriteRenderer>();
		SpriteRenderer HatSprite = PlayerHat.GetComponent<SpriteRenderer>();
		SpriteRenderer AnimalSprite = PlayerAnimal.GetComponent<SpriteRenderer>();
		
		//check all parts
		//body
		switch(PlayerPrefs.GetInt("PlayerBody", 0)){
			case(0):
				BodySprite.sprite = Body1;
			break;
			case(1):
				BodySprite.sprite = Body2;
			break;
			case(2):
				BodySprite.sprite = Body3;
			break;
			case(3):
				BodySprite.sprite = Body4;
			break;
		}
		
		//eyes
		switch(PlayerPrefs.GetInt("PlayerEyes", 0)){
			case(0):
				EyesSprite.sprite = Eyes1;
			break;
			case(1):
				EyesSprite.sprite = Eyes2;
			break;
			case(2):
				EyesSprite.sprite = Eyes3;
			break;
			case(3):
				EyesSprite.sprite = Eyes4;
			break;
		}
		
		//mouth
		switch(PlayerPrefs.GetInt("PlayerMouth", 0)){
			case(0):
				MouthSprite.sprite = Mouth1;
			break;
			case(1):
				MouthSprite.sprite = Mouth2;
			break;
		}
		
		//hair
		switch(PlayerPrefs.GetInt("PlayerHair", 0)){
			case(0):
				HairSprite.sprite = Hair1;
			break;
			case(1):
				
			break;
		}
		
		//clothes
		switch(PlayerPrefs.GetInt("PlayerClothes", 0)){
			case(0):
				ClothesSprite.sprite = Robe1Red;
			break;
			case(1):
				ClothesSprite.sprite = Robe1Blue;
			break;
			case(2):
				ClothesSprite.sprite = Robe1Green;
			break;
			case(3):
				ClothesSprite.sprite = Robe1Grey;
			break;
			case(4):
				ClothesSprite.sprite = Robe1Orange;
			break;
			case(5):
				ClothesSprite.sprite = Robe1Purple;
			break;
			case(6):
				ClothesSprite.sprite = Robe2Red;
			break;
			case(7):
				ClothesSprite.sprite = Robe2Blue;
			break;
			case(8):
				ClothesSprite.sprite = Robe2Green;
			break;
			case(9):
				ClothesSprite.sprite = Robe2Grey;
			break;
			case(10):
				ClothesSprite.sprite = Robe2Orange;
			break;
			case(11):
				ClothesSprite.sprite = Robe2Purple;
			break;
			case(12):
				ClothesSprite.sprite = Robe3Red;
			break;
			case(13):
				ClothesSprite.sprite = Robe3Blue;
			break;
			case(14):
				ClothesSprite.sprite = Robe3Green;
			break;
			case(15):
				ClothesSprite.sprite = Robe3Grey;
			break;
			case(16):
				ClothesSprite.sprite = Robe3Orange;
			break;
			case(17):
				ClothesSprite.sprite = Robe3Purple;
			break;
			case(18):
				ClothesSprite.sprite = Clothes1;
			break;
		}
		
		//hat
		switch(PlayerPrefs.GetInt("PlayerHat", 0)){
			case(0):
				HatSprite.sprite = Hat1;
			break;
			case(1):
				
			break;
		}
		
		//animal
		switch(PlayerPrefs.GetInt("PlayerAnimal", 0)){
			case(0):
				AnimalSprite.sprite = Bunny;
			break;
			case(1):
				AnimalSprite.sprite = Turtle;
			break;
		}
	}
	
	//setting methods
	//set body
	public void SetPlayerBody(int body){
		PlayerPrefs.SetInt("PlayerBody", body);
	}
	
	//set eyes
	public void SetPlayerEyes(int eyes){
		PlayerPrefs.SetInt("PlayerEyes", eyes);
	}
	
	//set mouth
	public void SetPlayerMouth(int mouth){
		PlayerPrefs.SetInt("PlayerMouth", mouth);
	}
	
	//set hair
	public void SetPlayerHair(int hair){
		PlayerPrefs.SetInt("PlayerHair", hair);
	}
	
	//set clothes
	public void SetPlayerClothes(int clothes){
		PlayerPrefs.SetInt("PlayerClothes", clothes);
	}
	
	//set hat
	public void SetPlayerHat(int hat){
		PlayerPrefs.SetInt("PlayerHat", hat);
	}
	
	//set animal
	public void SetPlayerAnimal(int animal){
		PlayerPrefs.SetInt("PlayerAnimal", animal);
	}
}
