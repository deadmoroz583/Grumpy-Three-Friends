using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Epilog : MonoBehaviour
{
	public void PlayPressed()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
