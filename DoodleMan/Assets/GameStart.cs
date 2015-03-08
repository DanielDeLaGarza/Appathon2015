using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public string level = "level1";

	public void loadLevel() {
		Application.LoadLevel (level);
	}
}
