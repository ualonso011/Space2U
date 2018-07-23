using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	//Shared
	public Vector3 spawnValues, planetSpawnValues;
	public float startWait, enemyShipSpawnWait, planetsSpawnWait, astronautSpawnWait, asteroidsSpawnWait, asteroidswaveWait;
	public GameObject[] enemyShips, planets, asteroids;
	public int followingEnemyFrecuency, asteroidsCount, score = 0;
	public GameObject astronaut, player, gameOverPanel;
	public Text scoreText;
	public GameController gameController;

	void Start ()
	{
		gameController = this;
		StartCoroutine (SpawnAsteroidWaves ());
		StartCoroutine (SpawnAstronaut ());
		StartCoroutine (SpawnEnemyShip ());
		StartCoroutine (SpawnPlanets());
	}

	GameController getGameController(){
		return gameController;
	}
	void Awake(){
		gameOverPanel.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public IEnumerator SpawnAsteroidWaves ()
	{
		yield return new WaitForSeconds (startWait);
		WaitForSeconds asteroidswaveWait1 = new WaitForSeconds (asteroidswaveWait);
		WaitForSeconds asteroidsSpawnWait1 = new WaitForSeconds (asteroidsSpawnWait);
		GameObject asteroid;
		Vector3 spawnPosition;
		Quaternion spawnRotation;

		while (true)
		{
			for (int i = 0; i < asteroidsCount; i++)
			{
				 asteroid = asteroids [Random.Range (0, asteroids.Length)];
				 spawnPosition = new Vector3 ( spawnValues.x, Random.Range(-spawnValues.y , spawnValues.y), spawnValues.z);
				 spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return asteroidsSpawnWait1;
			}
			yield return asteroidswaveWait1;

		}
	}

	IEnumerator SpawnAstronaut ()
	{
		yield return new WaitForSeconds (startWait);
		WaitForSeconds astronautSpawnWait1 = new WaitForSeconds (astronautSpawnWait);
		float val;
		Vector3 spawnPosition;
		Quaternion spawnRotation;
		while (true)
		{

			 val = Random.Range (1, 2);
			yield return new WaitForSeconds  (astronautSpawnWait * val);
			 spawnPosition = new Vector3 ( spawnValues.x, Random.Range(-spawnValues.y , spawnValues.y), spawnValues.z);
			 spawnRotation = Quaternion.identity;
			Instantiate (astronaut, spawnPosition, spawnRotation);
			}
	}
		
	IEnumerator SpawnEnemyShip ()
	{
		yield return new WaitForSeconds (startWait);
		int count = 0, shipNumber = 0;
		float val;
		Vector3 spawnPosition;
		Quaternion spawnRotation;
		int number;
		while (true)
		{

			 val = Random.Range (1, 2);
			yield return new WaitForSeconds (enemyShipSpawnWait * val);
			 spawnPosition = new Vector3 ( spawnValues.x, Random.Range(-spawnValues.y , spawnValues.y), spawnValues.z);
			 spawnRotation = Quaternion.Euler(0,180f,0);
			if (count < followingEnemyFrecuency) {
				count++;
				Instantiate (enemyShips[shipNumber], spawnPosition, spawnRotation);
			} else {
				 number = Random.Range (1, 3);
				if (number == 1) {
					 spawnPosition = new Vector3 ( spawnValues.x, player.transform.localPosition.y, spawnValues.z);
					Instantiate (enemyShips [shipNumber + 1], spawnPosition, spawnRotation);
					count = 0;
				} else {
					Instantiate (enemyShips [shipNumber ], spawnPosition, spawnRotation);
				}
			}
		}
	}


 
	public bool FirstPlanet = true;

	IEnumerator SpawnPlanets ()
	{
		yield return new WaitForSeconds (startWait);
		GameObject planet; 
		float val ;
		WaitForSeconds waitTime;
		Vector3 spawnPosition;
		Quaternion spawnRotation;
		while (true)
		{
			for (int i =0; i < planets.Length; i++) {
				 planet = planets [i];
				 val = Random.Range (1, 2);
				waitTime = new WaitForSeconds (System.Convert.ToSingle (planetsSpawnWait + (planetsSpawnWait * 0.1 * val)));
				if (FirstPlanet == false) yield return waitTime;
				 spawnPosition = new Vector3 (Random.Range (planetSpawnValues.x, (planetSpawnValues.x/2)), Random.Range (-planetSpawnValues.y, planetSpawnValues.y), planetSpawnValues.z);
				 spawnRotation = Quaternion.identity;
				Instantiate (planet, spawnPosition, spawnRotation);
				FirstPlanet = false;

			}
		}
	}

	public void GameOver(){
		gameOverPanel.SetActive (true);
		//gameOverText.text = "GAME OVER";
	}

}