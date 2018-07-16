using UnityEngine;
using System.Collections;

public class contactAstronaut : MonoBehaviour
{
	public GameObject explosion;
	private GameController gameController;

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
	}

	//Explodes only when the astronaut is hitten by a bullet
	void OnTriggerEnter (Collider other)
	{
		if  (other.tag == "Player" )
		{
			if  (explosion!=null) Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
			gameController.score = gameController.score + 50;
			gameController.scoreText.text = "SCORE = " + gameController.score;
		}

		if  (other.tag == "Weapon" || other.tag == "EnemyWeapon" || other.tag == "Enemy" )
		{
			if  (explosion!=null) Instantiate(explosion, transform.position,Quaternion.identity);
			if  (other.tag == "Weapon" || other.tag == "EnemyWeapon") Destroy (other.gameObject);
			Destroy (gameObject);
			if (gameController.score < 10) {
				gameController.score = 0;
			} else {
					gameController.score = gameController.score - 10;
			}
			gameController.scoreText.text = "SCORE = " + gameController.score;
		}
	}
}