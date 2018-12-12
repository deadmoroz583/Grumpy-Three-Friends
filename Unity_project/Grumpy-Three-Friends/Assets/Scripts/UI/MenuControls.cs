using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
	
	public void PlayPressed()
    {
		GlobalNames.ach[0] = 1;
        SceneManager.LoadScene("Level_Frog_1");
    }
	
	public void ExitPressed()
    {
		Debug.Log("Exit pressed!");
        Application.Quit();
    }
	
}
