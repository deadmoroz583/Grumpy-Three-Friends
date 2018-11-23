using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	public AudioSource music;
	
	void Start ()
	{
		music.volume = (float)GlobalNames.soundVolume;
	}
}
