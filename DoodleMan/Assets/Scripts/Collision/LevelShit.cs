﻿using UnityEngine;
using System.Collections;

public class LevelShit : MonoBehaviour {

	public string level = "";
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "DoodleMan") {
			other.SendMessage ("Die", SendMessageOptions.DontRequireReceiver);
			Application.LoadLevel(level);
		}
	}

}
