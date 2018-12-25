using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private string CurentSM;
    private string NextScene;
    private void Awake()
    {
        
       // NextScene = "Cat_2";
    }
    public void LoadifDead()
    {
        Debug.Log("LOAD");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadifFinal()
    {
        CurentSM = SceneManager.GetActiveScene().name;
        if (CurentSM == "Level_Frog_1") { NextScene = "Level_Frog_2"; }
        if (CurentSM == "Level_Frog_2") { NextScene = "Level_Frog_3"; }
        if (CurentSM == "Level_Frog_3") { NextScene = "Level_Dog_1"; }
        if (CurentSM == "Level_Dog_1") { NextScene = "Level_Dog_2"; }
        if (CurentSM == "Level_Dog_2") { NextScene = "Level_Dog_3"; }
        if (CurentSM == "Level_Dog_3") { NextScene = "Cat_1"; }
        if (CurentSM == "Cat_1")
        {
            NextScene = "Cat_2";
           
        }
        if (CurentSM == "Cat_2") { NextScene = "Cat_3"; }
        if (CurentSM == "Cat_3") {
            GlobalNames.ach[5] = 1; NextScene = "Select"; }
        if (CurentSM == "Boss_level_cat" || CurentSM =="Boss_level_dog" || CurentSM == "Boss_level_frog") { GlobalNames.ach[6] = 1; NextScene = "Final_Epilog"; }

        SceneManager.LoadScene(NextScene);

    }
    
    public void Cat()
    {
        SceneManager.LoadScene("Boss_level_cat");
    }
    public void Dog()
    {
        SceneManager.LoadScene("Boss_level_dog");
    }
    public void Frog()
    {
        SceneManager.LoadScene("Boss_level_frog");
    }

    public void LoadifMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }


}
