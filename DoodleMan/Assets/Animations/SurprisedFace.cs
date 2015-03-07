using UnityEngine;
using System.Collections;

public class SurprisedFace : MonoBehaviour {

	public GameObject face;
	public Sprite headSprite;

	void setSurprisedFace() {
		face.GetComponent<SpriteRenderer>().sprite = headSprite;
	}
}
