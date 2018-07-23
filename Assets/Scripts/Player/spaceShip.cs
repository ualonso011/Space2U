using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShip : MonoBehaviour {
	[SerializeField]
	private float jumpForce = 500f;
	private Rigidbody rb;
	private MeshCollider ship;
	private float nextFire;
	private GameController gameController;
	public bool exploted;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private Touch[] myTouches;

	private void Awake(){
		rb = GetComponent<Rigidbody> ();
		ship = GetComponent<MeshCollider> ();
		exploted = false;
	}
/*	private void Update () {
		//rb.isKinematic = true;
		ship.isTrigger = true;
		if (Input.GetKeyDown ("space")) {
			rb.AddForce (Vector2.up * jumpForce);
		}
		if (Input.GetKeyDown ("return")) {
			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				//GetComponent<AudioSource>().Play ();
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			if (Input.mousePosition.x < Screen.width / 2) {
				//Jump spaceShip
				if (Input.GetButtonDown ("Fire1")) {
					//rb.velocity = Vector2.zero;
					rb.AddForce (Vector2.up * jumpForce);
				}
			} else if (Input.mousePosition.x > Screen.width / 2) {
				//Shot
				if (Time.time > nextFire) {
					nextFire = Time.time + fireRate;
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
					//GetComponent<AudioSource>().Play ();
				}
			}
		}
	}
	*/

	//=========================================Mobileako=================================================//


	  	private void Update () {
		ship.isTrigger = true;
		//Touch myTouch = Input.GetTouch (0);
		myTouches = Input.touches;
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetMouseButtonDown (i)) {
				if (myTouches[i].position.x < Screen.width / 2) {
					//Jump spaceShip
					if (Input.GetButtonDown ("Fire1")) {
						//rb.velocity = Vector2.zero;
						rb.AddForce (Vector2.up * jumpForce);
					}
				} else if (myTouches[i].position.x > Screen.width / 2) {
					//Shot
					if (Time.time > nextFire) {
						nextFire = Time.time + fireRate;
						Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
						//GetComponent<AudioSource>().Play ();
					}
				}
			}
		}
	}

}
