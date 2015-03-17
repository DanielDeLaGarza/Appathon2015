using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Basic Character Attributes
	public int health = 1;
	public float jumpVelocity = 7f;
	protected Animator animator;
	public bool walledLeft = false;
	public bool walledRight = false;
	public bool grounded = true;
	public GameObject sprites;
	private float moveSpeed = 2f;

	private bool left = false, right = false, up = false;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponentInChildren<Animator> ();
	}

	void Update ()
	{
		moveKeys();
	}

	void die ()
	{	
		Application.LoadLevel (Application.loadedLevel);
	}

	//Moves character in the right directon
	private void moveAcelerometer(){

		moveSpeed = Input.acceleration.x * 10f;
		Vector3 scale = sprites.transform.localScale;
		if (moveSpeed < -.6f) {
			scale.x = Mathf.Abs (scale.x) * -1;
		} else if (moveSpeed > .6f) {
			scale.x = Mathf.Abs (scale.x);
		}
		transform.localScale = scale;
		if (moveSpeed > -1f && moveSpeed < 1f) {
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isWalking", false);
		} else if (Mathf.Abs (moveSpeed) > 3.5) {
			animator.SetBool ("isRunning", true);
			animator.SetBool ("isWalking", false);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isWalking", true);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}

	//////////////////////////////////////////////////////
	private void moveKeys(){
		animator.SetBool ("isWalking", false);
		if (!grounded) {
			animator.SetBool ("isFalling", true);
			animator.SetBool ("isJumping", false);
		} else {
			animator.SetBool("isFalling", false);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)&&!Input.GetKeyDown(KeyCode.RightArrow)){
			left = false;
			animator.SetBool("isRunning", false);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)&&!Input.GetKeyDown(KeyCode.LeftArrow)) {
			right = false;
			animator.SetBool("isRunning", false);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			left = true;
			Vector3 scale = sprites.transform.localScale;
			if(scale.x > 0)scale.x *= -1;
			sprites.transform.localScale = scale;
			animator.SetBool("isRunning", true);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			right = true;
			Vector3 scale = sprites.transform.localScale;
			if(scale.x < 0)scale.x *= -1;
			sprites.transform.localScale = scale;
			animator.SetBool("isRunning", true);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			up = true;
		}
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			up = false;
		}
		if (left){
			if(!(!grounded&&walledLeft))GetComponent<Rigidbody2D>().velocity = new Vector2(-4.5f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (right){
			if(!(!grounded&&walledRight))GetComponent<Rigidbody2D>().velocity = new Vector2(4.5f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (up) {
			animator.SetBool("isJumping", true);
		}
		if (!(left | right)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
	//Public Functions////////////////////////////////////
	public void jump(){

		if(grounded)GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpVelocity);

	}
	public void setGrounded(bool b){
		grounded = b;
	}
	public void setWalledLeft(bool b){
		walledLeft = b;
	}
	public void setWalledRight(bool b){
		walledRight = b;
	}
}
