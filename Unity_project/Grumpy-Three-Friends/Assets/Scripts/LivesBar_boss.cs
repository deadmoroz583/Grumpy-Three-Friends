using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar_boss : MonoBehaviour {

    private Transform[] hearts = new Transform[5];
    public Boss boss;


    private void Awaken()
    {
        boss = FindObjectOfType<Boss>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
            Debug.Log(hearts[i]);
        }
    }
    private void Start()
    {
        boss = FindObjectOfType<Boss>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
            Debug.Log(hearts[i]);
        }
    }

    public void Refresh2()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < boss.Lives_b) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}

