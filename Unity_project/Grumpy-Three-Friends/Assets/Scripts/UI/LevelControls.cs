using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControls : MonoBehaviour
{
	public void ToMenu()
	{
		SceneManager.LoadScene("Main_Menu");
	}
}
