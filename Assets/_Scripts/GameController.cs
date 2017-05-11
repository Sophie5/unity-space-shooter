using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {
	 
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText GameOverText;
	public GUIText RestartText;

	private int counter;
	private int score;
	private bool gameOver;
	private bool restart;

	void Start () {
		counter = 0;
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		gameOver = false;
		restart = false;
		RestartText.text = "";
		GameOverText.text = "";

	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < (hazardCount*counter); i++) {
				GameObject hazard = hazards [Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (spawnValues.x, -spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			counter += 1;

			if (gameOver) {
				RestartText.text = "Press 'R' For Restart";
				restart = true;
				break;
			}
		}
	}


	void Update ()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () 
	{
		scoreText.text = "Score:" + score;
	}

	public void GameOver ()
	{
		GameOverText.text = "GameOver!";
		gameOver = true;
	}

}
