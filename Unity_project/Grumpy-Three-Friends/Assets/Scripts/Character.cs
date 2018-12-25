using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit {

    
    [SerializeField]
    private int lives = 3;
    public LivesBar livesbar;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 3) lives = value;
            livesbar.Refresh();
            Debug.Log("Refresh");
        }
    }
    
    private LoadScene ls;
    // PauseS ps1;
    [SerializeField]
    private float ForceValue = 8.0f;
    //[SerializeField]
    public float speed = 3F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private CharStage State
    {
        get { return (CharStage)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private int checkHitDelay;

    private void Awake()
    {
        ls = new LoadScene();
        
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Staart()
    {
        ls = new LoadScene();
       // livesbar = new LivesBar();
        livesbar = FindObjectOfType<LivesBar>();
        checkHitDelay = 0;

        //  ps1 = new PauseS();
    }
    private void FixedUpdate()
    {
            CheckGround();
            if (Input.GetButton("Horizontal")) Run();     
    }

    private void Update()
    {
        
            if (isGrounded) State = CharStage.Idle;
            if (Input.GetButton("Horizontal")) State = CharStage.Run;
            if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    
    }
    void HitDelay()
    {
        checkHitDelay = 1;
        InvokeRepeating("RemoveHitDelay", 2, 0);
    }

    void RemoveHitDelay()
    {
        checkHitDelay = 0;
    }

    public override void isForce(Vector3 poz)
    {
        rigidbody.velocity = Vector3.zero;
        Vector3 dir = (transform.position - poz);
        rigidbody.AddForce(dir.normalized * ForceValue*2.5F, ForceMode2D.Impulse);
    }
    public override void ReceiweDamage(Vector3 poz)
    {
        if(checkHitDelay == 0)
        {
            Debug.Log("жизни до удара" + lives + Lives);
            Lives--;
            Debug.Log("жизни до после удара" + lives + Lives);
            Debug.Log(poz);
            rigidbody.velocity = Vector3.zero;
            Vector3 dir = (transform.position - poz);
            Debug.Log(dir);
            //dir.Normalize();
            rigidbody.AddForce(dir.normalized * ForceValue, ForceMode2D.Impulse);

            // rigidbody.AddForce((transform.up) * 100, ForceMode2D.Impulse);
            Debug.Log(lives);
            Dead();
            HitDelay();
        }     
    }

    private void Dead()
    {
        if (Lives == 0)
        {
            ls.LoadifDead();
        }
            
    }

    private void Run()
    {
        
        
        //float h = Input.GetAxisRaw("Horizontal");


        // Vector2 tempVect = new Vector2(h,0);
        //tempVect = tempVect.normalized * transform.right* speed * Time.fixedDeltaTime;
        //rigidbody.MovePosition((Vector2)transform.position + tempVect);
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.Translate(direction.x * speed * Time.deltaTime, 0, 0);
        // transform.position = Vector3.Lerp(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;
        // sprite.flipX = tempVect.x < 0.0F;

    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        State = CharStage.Run;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        
        isGrounded = colliders.Length > 1;
        foreach (Collider2D coll in colliders)
        {
            Unit unit = coll.GetComponent<Unit>();
            if (unit && !(unit is Character))
            {
                Debug.Log("In foreach and If");
                isGrounded = false;
            }
        }
    }
}

public enum CharStage
{
    Idle,
    Run
}