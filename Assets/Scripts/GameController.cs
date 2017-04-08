using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text restartText;
	public UnityEngine.UI.Text gameoverText;
	private bool isGameOver;

	private int score;

	// Use this for initialization
	void Start () {
		isGameOver = false;
		restartText.text = "";
		gameoverText.text = "";
		StartCoroutine(SpawnWaves ());
	}

	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (
                       Random.Range (-spawnValues.x, spawnValues.x),
                       spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			if (isGameOver) {
				restartText.text = "Press 'R' to respawn";
				gameoverText.text = "Game Over!";
				break;
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	private void UpdateScore(){
		scoreText.text = "Score: " + score;
	}
	public void GameOver(){
		isGameOver = true;
	}
}
