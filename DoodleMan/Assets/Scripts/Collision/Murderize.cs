﻿using UnityEngine;
using System.Collections;

public class Murderize : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "DoodleMan") {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

}
