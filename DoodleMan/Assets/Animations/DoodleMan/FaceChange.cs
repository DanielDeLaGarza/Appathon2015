using UnityEngine;
using System.Collections;

public class FaceChange : MonoBehaviour {

	public GameObject face;

	void setRandomFace(){
		int FaceNum = Random.Range (1, 3);
		face.GetComponent<SpriteRenderer>.sprite = 
	}
	void setDefaultFace(){

	}
}
