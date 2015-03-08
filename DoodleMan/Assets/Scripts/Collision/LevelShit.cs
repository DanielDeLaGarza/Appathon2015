using UnityEngine;
using System.Collections;

public class LevelShit : MonoBehaviour {

	public string level = "";
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "DoodleMan") {
<<<<<<< HEAD
			other.SendMessage ("Die", SendMessageOptions.DontRequireReceiver);
=======
			Destroy(other.gameObject);
>>>>>>> 403ffee5672ace2c21e7180fb7eab61c83cdec81
			Application.LoadLevel(level);
		}
	}

}
