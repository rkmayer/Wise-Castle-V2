using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUIScript : MonoBehaviour
{
	
	GameObject ui;
	CanvasGroup ui_group;
	
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindWithTag("UI");
		ui_group = ui.GetComponent<CanvasGroup>();
		hideUI();
    }
	
	public void showUI(){
		ui_group.alpha = 1f;
		ui_group.blocksRaycasts = true;
	}
	
	public void hideUI(){
		ui_group.alpha = 0f;
		ui_group.blocksRaycasts = false;
	}
}
