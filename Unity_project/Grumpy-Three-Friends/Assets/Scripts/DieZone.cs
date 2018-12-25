using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour {

    private Character character;
    
   
	private void Awake()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        character = collider.GetComponent<Character>();
        Debug.Log(character.GetInstanceID());
        if (character)
        {
            LoadScene ls = new LoadScene();
            Debug.Log("ZONA!");
            ls.LoadifDead();
            
        }
        Debug.Log("ZONA  end!");
    }

}
