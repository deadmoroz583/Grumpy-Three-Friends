using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finel : MonoBehaviour {

    private Character character;

    [SerializeField]
    private GameObject DiagPanel;
    [SerializeField]
    private GameObject DiagBar_end;



    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        character = collider.GetComponent<Character>();
        Debug.Log(character.GetInstanceID());
        if (character)
        {
            DiagPanel.SetActive(true);
            DiagBar_end.SetActive(true);
            //LoadScene ls1 = new LoadScene();
            Debug.Log("ZONA!");
            //ls1.LoadifFinal();
        }
        
    }
}
