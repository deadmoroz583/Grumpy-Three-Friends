using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	public float JumpForce;
	public bool IsGround;
	Rigidbody2D PlRgb;
	SpriteRenderer PlSpr;
	
	void Awake()
	{
		PlRgb = GetComponent<Rigidbody2D>();
		PlSpr = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			PlRgb.velocity = new Vector2(Speed, PlRgb.velocity.y);
			PlSpr.flipX = false;
		}
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			PlRgb.velocity = new Vector2(-Speed, PlRgb.velocity.y);
			PlSpr.flipX = true;
		}
		else
		{
			PlRgb.velocity = new Vector2(PlRgb.velocity.x, PlRgb.velocity.y);
		}
		if (Input.GetButtonDown("Jump") && IsGround)
		{
			PlRgb.velocity = new Vector2(PlRgb.velocity.x, JumpForce);
		}
	}
	
	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.gameObject.tag == "Ground")
		{
			IsGround = true;
		}
	}
	
	void OnTriggerExit2D (Collider2D Other)
	{
		if (Other.gameObject.tag == "Ground")
		{
			IsGround = false;
		}
	}
}