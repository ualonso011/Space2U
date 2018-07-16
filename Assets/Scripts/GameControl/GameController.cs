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

	void Start ()
	{
		StartCoroutine (SpawnAsteroidWaves ());
		StartCoroutine (SpawnAstronaut ());
		StartCoroutine (SpawnEnemyShip ());
		StartCoroutine (SpawnPlanets());
	}

	void Awake(){
		gameOverPanel.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	IEnumerator SpawnAsteroidWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < asteroidsCount; i++)
			{
				GameObject asteroid = asteroids [Random.Range (0, asteroids.Length)];
				Vector3 spawnPosition = new Vector3 ( spawnValues.x, Random.Range(-spawnValues.y , spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (asteroidsSpawnWait);
			}
			yield return new WaitForSeconds (asteroidswaveWait);

		}
	}

	IEnumerator SpawnAstronaut ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{

			float val = Random.Range (1, 2);
			yield return new WaitForSeconds (astronautSpawnWait * val);
			Vector3 spawnPosition = new Vector3 ( spawnValues.x, Random.Range(-spawnValues.y , spawnValues.y), spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (astronaut, spawnPosition, spawnRotation);
			}
	}
		
	IEnumerator SpawnEnemyShip ()
	{
		yield return new WaitForSeconds (startWait);
		int count = 0, shipNumber = 0;
		while (true)
		{

			float val = Random.Range (1, 2);
			yield return new WaitForSeconds (enemyShipSpawnWait * val);
			Vector3 spawnPosition = new Vector3 ( spawnValues.x, Random.Range(-spawnValues.y , spawnValues.y), spawnValues.z);
			Quaternion spawnRotation = Quaternion.Euler(0,180f,0);
			if (count < followingEnemyFrecuency) {
				count++;
				Instantiate (enemyShips[shipNumber], spawnPosition, spawnRotation);
			} else {
				int number = Random.Range (1, 3);
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


		while (true)
		{
			for (int i =0; i < planets.Length; i++) {
				GameObject planet = planets [i];
				float val = Random.Range (1, 2);
				float waitTime = System.Convert.ToSingle (planetsSpawnWait + (planetsSpawnWait * 0.1 * val));
				if (FirstPlanet == false) yield return new WaitForSeconds (waitTime);
				Vector3 spawnPosition = new Vector3 (Random.Range (planetSpawnValues.x, (planetSpawnValues.x/2)), Random.Range (-planetSpawnValues.y, planetSpawnValues.y), planetSpawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
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