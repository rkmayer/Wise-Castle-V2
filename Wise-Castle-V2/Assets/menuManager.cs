using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public Button playerInfoBtn, englishBtn, artBtn, mathBtn, chemistryBtn;
	
	public void Start(){
		playerInfoBtn.onClick.AddListener(playConfirm);
		englishBtn.onClick.AddListener(playConfirm);
		artBtn.onClick.AddListener(playConfirm);
		mathBtn.onClick.AddListener(playConfirm);
		chemistryBtn.onClick.AddListener(playConfirm);
	}
	
	public void playConfirm(){
		GameObject.FindGameObjectWithTag("music").GetComponent<MusicScript>().PlayConfirmSound();
	}
}
