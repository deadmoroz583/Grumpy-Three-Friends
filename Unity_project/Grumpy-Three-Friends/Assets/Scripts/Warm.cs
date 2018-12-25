using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warm : MonoBehaviour {

    private Animator animator;
    //private SpriteRenderer sprite;

    private Vector3 poz;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        // sprite = GetComponentInChildren<SpriteRenderer>();
        animator.enabled = true;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            poz = transform.position;
            Debug.Log(poz);
           // poz = poz + new Vector3(0, 4, 0);
            Debug.Log(poz);
            Debug.Log("True");
            unit.ReceiweDamage(poz);
            Debug.Log("TrueDAMAGE");
        }
    }
}
