using UnityEngine;
using System.Collections;

public class FaceChange : MonoBehaviour {

	public GameObject face;
	public Sprite[] headSprites;


	public void setRandomFace(){
		int FaceNum = Random.Range (0,headSprites.Length);
		face.GetComponent<SpriteRenderer>().sprite = headSprites[FaceNum];
	}
	public void setDefaultFace(){
		face.GetComponent<SpriteRenderer>().sprite = headSprites[0];
	}
}
