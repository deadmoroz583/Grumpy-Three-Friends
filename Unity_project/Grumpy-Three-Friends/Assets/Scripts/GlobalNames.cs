using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalNames : MonoBehaviour
{
	public static double soundVolume;
	
	void Start()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Update()
	{
		
	}
}
