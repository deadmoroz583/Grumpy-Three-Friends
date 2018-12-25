using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseController;
    public LoadScene load;

    public void Awake()
    {
        load = new LoadScene();
    }
    public void Start()
    {
        load = new LoadScene();
    }
    public void PlayGame()
    {
        pauseController.GetComponent<PauseS>().RevertPaused();
    }

    public void MainMenu()
    {
        load.LoadifMenu();
    }

}
