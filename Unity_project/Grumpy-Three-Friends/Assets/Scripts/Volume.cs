using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
	
	public double soundVolume;
	
	public Slider slider;
	public AudioSource music;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		soundVolume = (double)slider.value;
		music.volume = (float)slider.value;
		
		GlobalNames.soundVolume = (float)slider.value;
	}
}
