using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public int speed;
	
	int lives;
	GameObject heart_1;
	GameObject heart_2;
	GameObject heart_3;
	
	GameObject pause;
	
	Vector3 platformsX;
	GameObject platforms;
	
	GameObject panel;
	Vector3 tempPosPanel;
	
	GameObject traps;
	Vector3 tempPosTraps;
	
	Vector3 tempPos;
	Vector3 tempPosX;
	
	new private Rigidbody2D rigidbody;
	public float jumpForce;
	
	private SpriteRenderer sprite;
	
	//находится ли персонаж на земле или в прыжке?
	private bool isGrounded = false;
	//ссылка на компонент Transform объекта
	//для определения соприкосновения с землей
	public Transform groundCheck;
	//радиус определения соприкосновения с землей
	private float groundRadius = 50;
	//ссылка на слой, представляющий землю
	public LayerMask whatIsGround;
	
	//Проверка стен
	private bool isColldR = false;
	public Transform wallCheckR;
	private bool isColldL = false;
	public Transform wallCheckL;
	private float wallRadius = 0.2f;
	
	//Столкновение с ловушками
	private bool isTrapped = false;
	public Transform trapCheck;
	private float trapRadius = 80;
	public LayerMask whatIsTrap;
	
	int checkHitDelay;
	
	// Use this for initialization
	void Start ()
	{		
		
		sprite = GetComponentInChildren<SpriteRenderer>();
		
		heart_1 = GameObject.Find("Heart_1");
		heart_2 = GameObject.Find("Heart_2");
		heart_3 = GameObject.Find("Heart_3");
		
		pause = GameObject.Find("Pause");
		pause.SetActive(false);
		
		panel = GameObject.Find("Background");
		tempPosPanel = panel.transform.position;
		
		traps = GameObject.Find("Traps");
		tempPosTraps = traps.transform.position;
		
		platforms = GameObject.Find("Platforms");
		platformsX = new Vector3(speed, 0, 0);
		
		tempPos = transform.position;
		tempPosX = new Vector3(speed, 0, 0);
		
		rigidbody = GetComponent<Rigidbody2D>();
		
		checkHitDelay = 0;
		
		lives = 3;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		
		Pause();
		
		tempPos = transform.position;
		
		MoveRight();
		MoveLeft();
		Jump();
		
		if (transform.position.y < -300)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		
		Trapped();
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
	
	void Trapped()
	{
		isTrapped = Physics2D.OverlapCircle(trapCheck.position, trapRadius, whatIsTrap); 
		if (!isTrapped)
			return;
		if (isTrapped  && pause.activeSelf == false)
		{
			if (checkHitDelay == 0)
			{
				lives--;
				if (lives == 2)
				{
					heart_3.SetActive(false);					
				}
				if (lives == 1)
				{
					heart_2.SetActive(false);			
				}
				if (lives == 0)
				{
					heart_1.SetActive(false);
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				
				HitDelay();				
			}
		}
	}
	
	void Pause()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (pause.activeSelf == false)
			{
				pause.SetActive(true);
			}
			else
			{
				pause.SetActive(false);
			}
		}
	}
	
	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space) && pause.activeSelf == false)
		{
			//определяем, на земле ли персонаж
			isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
			//если персонаж в прыжке - выход из метода, чтобы не выполнялись действия, связанные с бегом
			if (!isGrounded)
				return;
			if (isGrounded)
			{
				rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
			}
		}
	}
	
	void MoveRight()
	{
		if (Input.GetKey (KeyCode.D) && pause.activeSelf == false)
		{
			isColldR = Physics2D.OverlapCircle(wallCheckR.position, wallRadius, whatIsGround); 
			if (isColldR)
				return;
			if (!isColldR)
			{
				if (tempPos.x < 200)
				{
					transform.position += tempPosX;
				}
				else
				{
					if (tempPosPanel.x - speed > -1280)
					{
						tempPosPanel.x -= speed;
						panel.transform.position = tempPosPanel;
						tempPosTraps.x -= speed;
						traps.transform.position = tempPosTraps;
						platformsX.x -= speed;
						platforms.transform.position = platformsX;
					}
					else
					{
						tempPosPanel.x = 0;
					}
				}
				sprite.flipX = false;
			}
		}
	}
	
	void MoveLeft()
	{
		if (Input.GetKey (KeyCode.A) && pause.activeSelf == false)
		{
			isColldL = Physics2D.OverlapCircle(wallCheckL.position, wallRadius, whatIsGround); 
			if (isColldL)
				return;
			if (!isColldL)
			{
				if (tempPos.x > -200)
				{
					transform.position -= tempPosX;
				}
				else
				{
					if (tempPosPanel.x + speed < 1280)
					{
						tempPosPanel.x += speed;
						panel.transform.position = tempPosPanel;
						tempPosTraps.x += speed;
						traps.transform.position = tempPosTraps;
						platformsX.x += speed;
						platforms.transform.position = platformsX;
					}
					else
					{
						tempPosPanel.x = 0;
					}
				}
				sprite.flipX = true;
			}
			
		}
	}
}
