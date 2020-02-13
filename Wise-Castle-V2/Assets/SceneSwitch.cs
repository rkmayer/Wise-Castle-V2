using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
	public void LoadMainScene(){
		SceneManager.LoadScene("main");
	}
	
    public void LoadArtScene(){
		SceneManager.LoadScene("art");
    }

    public void LoadEnglishScene(){
		SceneManager.LoadScene("english");
    }

	public void LoadChemScene(){
		SceneManager.LoadScene("chemistry");
	}
	
	public void LoadMathScene(){
		SceneManager.LoadScene("math");
	}
	
	public void LoadPlayerScene(){
		SceneManager.LoadScene("player");
	}
	
	public void LoadShopScene(){
		SceneManager.LoadScene("shop");
	}
	
	public void LoadArtTutorial(){
		SceneManager.LoadScene("tutorial_art");
	}
	
	public void LoadChemTutorial(){
		SceneManager.LoadScene("tutorial_chem");
	}
	
	public void LoadEnglishTutorial(){
		SceneManager.LoadScene("tutorial_english");
	}
	
	public void LoadMathTutorial(){
		SceneManager.LoadScene("tutorial_math");
	}
}