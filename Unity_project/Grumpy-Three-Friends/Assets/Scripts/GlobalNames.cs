using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalNames : MonoBehaviour
{
	public static double soundVolume;
	public static int[] ach = {0, 0, 0, 0, 0, 0, 0};
	public RawImage[] achimg = new RawImage[7];
	public Texture m_Texture;
	
	void Start()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Update()
	{
		if (SceneManager.GetActiveScene().name == "Main_Menu")
		{
			for (int i = 0; i <= 6; i++)
			{
				if (ach[i] == 1)
				{
					achimg[i].texture = m_Texture;
				}
			}
		}
	}
}
