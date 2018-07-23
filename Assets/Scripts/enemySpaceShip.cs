using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpaceShip : MonoBehaviour {
	private GameController gameController;
	private  GameObject smokeEffect, engine;
	private int life; 
	public int Max_life, points_by_hit, point_destroy; 
	public GameObject explosion_destroy, explosion_hit;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		if (transform.childCount > 3) {
			smokeEffect = transform.GetChild (3).gameObject;
			engine = transform.GetChild (1).gameObject;
			smokeEffect.SetActive (false);
		}
		life = Max_life;
	}
	public void enableSmoke(){
		if (engine != null && smokeEffect != null) {
			engine.SetActive (false);
			smokeEffect.SetActive (true);
		}
	}
	public void score_hit(){
		gameController.score = gameController.score + points_by_hit;
		gameController.scoreText.text = "SCORE = " + gameController.score;
	}
	public void score_destroy(){
		gameController.score = gameController.score + point_destroy;
		gameController.scoreText.text = "SCORE = " + gameController.score;
	}
	public void hitByBullet(){
		if (life == Max_life)
			enableSmoke ();
		life--;
		if (life == 0) {
			if (explosion_destroy != null)
				Instantiate (explosion_destroy, transform.position, transform.rotation);
			Destroy (gameObject);
			score_destroy ();
		} else {
			if (explosion_hit != null)
				Instantiate (explosion_hit, transform.position, transform.rotation);
			score_hit ();
		}
	}
	public void hitByEnemyBullet(){
		if (life == Max_life)
			enableSmoke ();
		life--;
		if (life == 0) {
			if (explosion_destroy != null)
				Instantiate (explosion_destroy, transform.position, transform.rotation);
			Destroy (gameObject);
		} else {
			if (explosion_hit != null)
				Instantiate (explosion_hit, transform.position, transform.rotation);
		}
	}
	public void hitByAsteroid(){
		Destroy (gameObject);
		if (explosion_destroy != null)
			Instantiate (explosion_destroy, transform.position, transform.rotation);
		score_destroy ();
	}
}
