using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Platform : MonoBehaviour {

   // public Transform trans;
    Vector3 target;

    void Start () {
     //   trans = GetComponent<Transform>();
         target = new Vector3(7000, 79, 0);
       // poz = trans.position.x;
	}

    // Update is called once per frame
    void Update() {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*100);
         if (transform.position.x == target.x)
        {
            target.x = 6400;
        }
         if (transform.position.x == target.x)
        {
            target.x = 7000;
        }
	}
}
