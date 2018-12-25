using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private Transform target;
    public GameObject dial;
    public GameObject ps;

    private void Awaken()
    {
       
        if (!target) target = FindObjectOfType<Character>().transform;
        
    }
    private void Start()
    {
        if (!target) target = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
       
     
        Vector3 pozition = target.position;
        if (pozition.y < 4.0f)
        {
           // Debug.Log(pozition.y);
            pozition.y = 5.0f;
          //  Debug.Log(pozition.y);
        }
        
       // pozition.z = -1;
        transform.position = Vector3.Lerp(transform.position, pozition,speed * Time.deltaTime);
    }
}
