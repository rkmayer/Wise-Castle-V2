using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
	public void LoadMainScene(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
		SceneManager.LoadScene("main");
	}
	
    public void LoadArtScene(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().StopBGMusic();
		SceneManager.LoadScene("art");
    }

    public void LoadEnglishScene(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().StopBGMusic();
		SceneManager.LoadScene("english");
    }

	public void LoadChemScene(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().StopBGMusic();
		SceneManager.LoadScene("chemistry");
	}
	
	public void LoadMathScene(){
		Debug.Log("yeah its doing it");
		SceneManager.LoadScene("math");
	}
	
	public void LoadPlayerScene(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
		SceneManager.LoadScene("player");
	}
	
	public void LoadShopScene(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
		SceneManager.LoadScene("shop");
	}
	
	public void LoadArtTutorial(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
		SceneManager.LoadScene("tutorial_art");
	}
	
	public void LoadChemTutorial(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
		SceneManager.LoadScene("tutorial_chem");
	}
	
	public void LoadEnglishTutorial(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
		SceneManager.LoadScene("tutorial_english");
	}
	
	public void LoadMathTutorial(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
		SceneManager.LoadScene("tutorial_math");
	}
}