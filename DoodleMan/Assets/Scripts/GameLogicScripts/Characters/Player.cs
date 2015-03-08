using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Basic Character Attributes
	public int health = 1;
	float moveSpeed = 2f;
	public float delay = 1f;
	public int jumpVelocity = 4;
	protected Animator animator;
	private bool canJump = true;
	public float nextUsage = 0f;

	private bool left = false, right = false, up = false;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(transform.gameObject);
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		if(nextUsage > 0) nextUsage = nextUsage - Time.deltaTime;
		Move ();
	}

	void Die ()
	{
		this.gameObject.SetActive (false);
		Destroy (this.gameObject);
		Application.LoadLevel (0);
	}

	//Moves character in the right directon
	void Move ()
	{
		moveSpeed = Input.acceleration.x*10f;
		Vector3 scale = transform.localScale;
		if (moveSpeed < -.6f) {
			scale.x = Mathf.Abs (scale.x) * -1;
		}
		else if (moveSpeed > .6f) {
			scale.x = Mathf.Abs(scale.x);
		}
		transform.localScale = scale;
		if (moveSpeed > -1f && moveSpeed < 1f) {
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isWalking", false);
		} else if (Mathf.Abs (moveSpeed) > 3.5) {
			animator.SetBool ("isRunning", true);
			animator.SetBool ("isWalking", false);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} 
		else {
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isWalking", true);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

		/*if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			left = true;
			Vector3 inverseScale = transform.localScale;
			if(inverseScale.x > 0)inverseScale.x *= -1;
			transform.localScale = inverseScale;
			animator.SetBool("isRunning", true);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			left = false;
			animator.SetBool("isRunning", false);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			right = true;
			Vector3 scale = transform.localScale;
			if(scale.x < 0)scale.x *= -1;
			transform.localScale = scale;
			animator.SetBool("isRunning", true);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			right = false;
			animator.SetBool("isRunning", false);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//animator.SetBool("isJumping", true);
			up = true;
		}
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			up = false;
		}
		if (left){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-5.3f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (right){
			GetComponent<Rigidbody2D>().velocity = new Vector2(5.3f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (!(left || up || right)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (GetComponent<Rigidbody2D>().velocity.y < 0) {
			animator.SetBool ("isFalling", true);
		} 
		else {
			animator.SetBool ("isFalling", false);
		}
		if (GetComponent<Rigidbody2D>().velocity.y > 0) {
			animator.SetBool ("isJumping", true);
		} 
		else {
			if(!up) animator.SetBool ("isJumping", false);
		}*/

	}
	public void jump(){
		if (nextUsage <= 0) {
			nextUsage = delay;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpVelocity);
		}

	}
	
}
