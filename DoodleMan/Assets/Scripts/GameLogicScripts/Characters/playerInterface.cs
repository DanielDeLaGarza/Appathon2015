using UnityEngine;
using System.Collections;

public class playerInterface : MonoBehaviour {

	public Player player;

	public void jump(){
		player.jump ();
	}

	public void setGrounded(bool b){
		player.setGrounded (b);
	}

	public void setWalledLeft(bool b){
		player.setWalledLeft (b);
	}

	public void setWalledRight(bool b){
		player.setWalledRight (b);
	}
}
