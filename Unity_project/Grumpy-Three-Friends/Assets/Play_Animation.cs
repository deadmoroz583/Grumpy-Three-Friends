using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play_Animation : MonoBehaviour {

    public Animation anim;
    private SpriteRenderer sprite;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        anim.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
