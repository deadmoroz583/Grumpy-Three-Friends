using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseS : MonoBehaviour
{
    private bool paused = false;
    public GameObject pausePanel;
    [SerializeField]
    private GameObject player;
    Character script;
    public GameObject DialPanel;


    private void Start()
    {
        script = player.GetComponent<Character>();
    }

    private void Update()
    {
        if (DialPanel.activeSelf == false)
        {
            Time.timeScale = 1;
            Debug.Log("DialogPanel is false and Time =" + Time.timeScale);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                RevertPaused();
            }
            if (paused == true)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                script.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
                script.enabled = true;
            }
        }
        else
        {
            Time.timeScale = 0;
            script.enabled = false;
            pausePanel.SetActive(false);
        }
    }

    public void RevertPaused()
    {
        paused = !paused;
    }
}


