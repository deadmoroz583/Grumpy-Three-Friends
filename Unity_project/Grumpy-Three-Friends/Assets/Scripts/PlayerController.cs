using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//переменная для установки макс. скорости персонажа
    public float maxSpeed = 10f; 
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;
	Rigidbody2D rigid2D;
	
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
	public LayerMask whatIsFinal;
	
	//Проверка стен
	private bool isColldR = false;
	public Transform wallCheckR;
	private bool isColldL = false;
	public Transform wallCheckL;
	private float wallRadius = 0.2f;
	
	//Проверка конца уровня (столкновение)
	private bool isColldFinal = false;
	
	//Столкновение с ловушками
	private bool isTrapped = false;
	public Transform trapCheck;
	private float trapRadius = 80;
	public LayerMask whatIsTrap;
	
	int checkHitDelay;
	
	// Use this for initialization
	void Start ()
	{		
		anim = GetComponent<Animator>();
		rigid2D = GetComponent<Rigidbody2D>();
		
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
		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{		
		Pause();
		//используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        float move = Input.GetAxis("Horizontal");

        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
        anim.SetFloat("Speed", Mathf.Abs(move));

        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        rigid2D.velocity = new Vector2(move * maxSpeed, rigid2D.velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if(move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
		
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
	
	private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
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
			{
				return;
			}
			if (isGrounded)
			{
				rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
			}
		}
	}
	
	void MoveRight()
	{
		if (Input.GetKey(KeyCode.D) && pause.activeSelf == false)
		{
			anim.enabled = true;
			
			isColldFinal = Physics2D.OverlapCircle(wallCheckR.position, wallRadius, whatIsFinal); 
			if (isColldFinal)
			{
				if (SceneManager.GetActiveScene().name == "Level_Frog_1")
				{
					SceneManager.LoadScene("Level_Dog_1");
				}
				if (SceneManager.GetActiveScene().name == "Level_Dog_1")
				{
					SceneManager.LoadScene("Level_Cat_1");
				}
				if (SceneManager.GetActiveScene().name == "Level_Cat_1")
				{
					SceneManager.LoadScene("Final_Boss");
				}
				if (SceneManager.GetActiveScene().name == "Final_Boss")
				{
					SceneManager.LoadScene("Main_Menu");
				}
			}
			
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
			}
		}
		if (Input.GetKeyUp(KeyCode.D) && pause.activeSelf == false)
		{
			anim.enabled = false;
		}
	}
	
	void MoveLeft()
	{
		if (Input.GetKey (KeyCode.A) && pause.activeSelf == false)
		{
			anim.enabled = true;
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
			}
		}
		if (Input.GetKeyUp(KeyCode.D) && pause.activeSelf == false)
		{
			anim.enabled = false;
		}
	}
}
