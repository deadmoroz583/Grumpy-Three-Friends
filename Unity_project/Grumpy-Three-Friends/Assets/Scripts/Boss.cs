using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Unit {

    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    //private float r = 4.25F;
    private int lives = 5;
    public LivesBar_boss livesbar_boss;
    public int Lives_b

    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesbar_boss.Refresh2();
            Debug.Log("Refresh_boss_lives");
        }
    }

    private Vector3 poz;
    private Animator anim;
    private SpriteRenderer sp;
    Vector3 defaultPoz;
    Vector3 target;
    Vector3 next;
    Vector3 NeedPoint;
    LoadScene end;
    //float R = 8.0F;
    //float k = 1;
  
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
        sp = GetComponentInChildren<SpriteRenderer>();

        
    }
    // Use this for initialization
    void Start ()
    {
        sp.flipX = true;
        defaultPoz = transform.position;
        target = new Vector3(8.0F, 0.52F, 0);
        end = new LoadScene();
	}
	
	// Update is called once per frame
	void Update ()
    {
                Move();
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (unit.transform.position.y > (transform.position.y + 4.25))
            {

                poz = transform.position;

                unit.isForce(poz);
                ReceiweDamage(poz);
            }
            else
           {
                poz = transform.position;
                Debug.Log(poz);
                Debug.Log("True");
                unit.ReceiweDamage(poz);
                Debug.Log("TrueDAMAGE");
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        Unit unit = other.GetComponent<Unit>();

        if (unit && unit is Character)
        {
                poz = transform.position;
                Debug.Log("True");
                unit.ReceiweDamage(poz);
                Debug.Log("TrueDAMAGE");
        }

        
    }
    private void Move()
    {
           
           // direction = transform.right*speed*0.5f*k;
        transform.position = Vector3.MoveTowards(transform.position, target,speed * Time.deltaTime);
        if(transform.position == target)
        {
            sp.flipX = !sp.flipX;
            target = defaultPoz;
            defaultPoz = transform.position;
        }
    }
    public override void ReceiweDamage(Vector3 poz)
    {
        //Debug.Log("жизни до удара" + lives + Lives);
        Lives_b--;
        Debug.Log("жизни после удара" + lives);
        Debug.Log(lives);
        Dead();
    }

    private void Dead()
    {
        if (Lives_b == 0)
        {
            end.LoadifFinal();
        }

    }
}
