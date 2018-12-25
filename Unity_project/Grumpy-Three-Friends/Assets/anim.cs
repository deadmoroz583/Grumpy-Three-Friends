using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anim : MonoBehaviour {

    public Animator anime;
   // public SpriteRenderer spr_Renderer;
   // GameObject dialog;
   // GameObject pause;
   // bool pauseOn;
    // Use this for initialization
   // void Awake()
   // {
//pause = GameObject.Find("Pause");
//}
    void Start () {
        anime = GetComponent<Animator>();
        anime.enabled = true;
       

        
       // dialog = GameObject.Find("DialogPanel");
          
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}

