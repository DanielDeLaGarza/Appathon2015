using UnityEngine;
using System.Collections;

public class LevelShit : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "DoodleMan") {
			Application.LoadLevel ("level2");
		}
	}

}
