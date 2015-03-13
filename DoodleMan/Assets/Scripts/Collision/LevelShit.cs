using UnityEngine;
using System.Collections;

public class LevelShit : MonoBehaviour {

	public string level = "";
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == 10){
			Application.LoadLevel(level);
		}
	}

}
