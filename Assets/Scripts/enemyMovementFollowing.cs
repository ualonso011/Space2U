

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementFollowing : MonoBehaviour {


	//Player
	private GameObject player;

	void Start(){
		player= GameObject.Find("spaceShip");
		if (player != null) {
			transform.localPosition = new Vector3 (transform.localPosition.x, player.transform.localPosition.y, transform.localPosition.z);
		}
	}
	void Update(){
		if (player != null) {
			transform.localPosition = new Vector3 (transform.localPosition.x, player.transform.localPosition.y, transform.localPosition.z);
		}
	}
}