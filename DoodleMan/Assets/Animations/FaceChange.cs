using UnityEngine;
using System.Collections;

public class FaceChange : MonoBehaviour {

	public GameObject face;
	public Sprite[] headSprites;


	void setRandomFace(){
		int FaceNum = Random.Range (0,headSprites.Length);
		face.GetComponent<SpriteRenderer>().sprite = headSprites[FaceNum];
	}
	void setDefaultFace(){
		face.GetComponent<SpriteRenderer>().sprite = headSprites[0];
	}
}
